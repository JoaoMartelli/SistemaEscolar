using Dapper;
using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class PresencaRepository : BaseRepository<PresencaDto>, IPresencaRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();

        public async Task<IEnumerable<PresencaDto>> GetByCursoDataAsync(int cursoId, DateTime data)
        {
            const string sql = @"
                SELECT 
                    p.PresencaID        AS PresencaId,
                    p.CursoID           AS CursoId,
                    p.AlunoID           AS AlunoId,
                    p.DataPresenca      AS DataPresenca,
                    p.StatusPresenca    AS StatusPresenca,
                    p.Justificativa     AS Justificativa,
                    p.Ativo             AS Ativo
                FROM Presenca p
                WHERE p.CursoID = @CursoId
                  AND p.DataPresenca = @Data
                  AND p.Ativo = 1;";

            var result = await _connection.QueryAsync<PresencaDto>(sql, new { CursoId = cursoId, Data = data.Date });

            await _auditoria.RegistrarAsync("Presenca", "SELECT_BY_CURSO_DATA", new { CursoId = cursoId, Data = data.Date });

            return result;
        }

        public async Task UpsertRangeAsync(IEnumerable<PresencaDto> presencas)
        {
            if (presencas == null) return;

            var wasClosed = _connection.State == ConnectionState.Closed;
            if (wasClosed) _connection.Open();

            using (var tran = _connection.BeginTransaction())
            {
                try
                {
                    foreach (var p in presencas)
                    {
                        var args = new
                        {
                            AlunoId = p.AlunoId,
                            CursoId = p.CursoId,
                            Data = p.DataPresenca.Date,
                            StatusPresenca = p.StatusPresenca,
                            Justificativa = string.IsNullOrWhiteSpace(p.Justificativa) ? null : p.Justificativa,
                            PresencaId = p.PresencaId
                        };

                        if (p.PresencaId.HasValue)
                        {
                            const string updateSql = @"
                                UPDATE Presenca
                                   SET StatusPresenca = @StatusPresenca,
                                       Justificativa  = @Justificativa,
                                       Ativo          = 1
                                 WHERE PresencaID    = @PresencaId;";
                            await _connection.ExecuteAsync(updateSql, args, tran);

                            await _auditoria.RegistrarAsync("Presenca", "UPDATE", args);
                        }
                        else
                        {
                            const string mergeSql = @"
                                MERGE Presenca AS target
                                USING (SELECT @AlunoId AS AlunoID, @CursoId AS CursoID, @Data AS DataPresenca) AS src
                                   ON target.AlunoID = src.AlunoID
                                  AND target.CursoID = src.CursoID
                                  AND target.DataPresenca = src.DataPresenca
                                WHEN MATCHED THEN
                                    UPDATE SET 
                                        StatusPresenca = @StatusPresenca,
                                        Justificativa  = @Justificativa,
                                        Ativo          = 1
                                WHEN NOT MATCHED THEN
                                    INSERT (CursoID, AlunoID, DataPresenca, StatusPresenca, Justificativa, Ativo)
                                    VALUES (@CursoId, @AlunoId, @Data, @StatusPresenca, @Justificativa, 1)
                                OUTPUT inserted.PresencaID;";

                            var newId = await _connection.ExecuteScalarAsync<int>(mergeSql, args, tran);
                            p.PresencaId = newId;

                            await _auditoria.RegistrarAsync("Presenca", "INSERT", args);
                        }
                    }

                    tran.Commit();
                }
                catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                {
                    tran.Rollback();
                    throw new Exception("Conflito de duplicidade: já existe presença para esse Aluno/Curso/Data.", ex);
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    if (wasClosed) _connection.Close();
                }
            }
        }
    }
}