using Dapper;
using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();

        public async Task<int> AddAsync(Aluno aluno)
        {
            var sql = @"INSERT INTO Aluno (NomeCompleto, CPF, Endereco, Cidade, UF, DataNascimento, Ativo) 
                        VALUES (@NomeCompleto, @CPF, @Endereco, @Cidade, @UF, @DataNascimento, @Ativo)";
            var response = await ExecuteAsync(sql, aluno);

            await _auditoria.RegistrarAsync("Aluno", "INSERT", aluno);

            return response;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            var sql = "SELECT * FROM Aluno WHERE Ativo = 1";
            var result = await QueryAsync(sql);

            //await _auditoria.RegistrarAsync("Aluno", "SELECT", null);

            return result;
        }

        public async Task<int> UpdateAsync(Aluno aluno)
        {
            var sql = @"UPDATE Aluno 
                        SET NomeCompleto = @NomeCompleto, CPF = @CPF, Endereco = @Endereco, 
                            Cidade = @Cidade, UF = @UF, DataNascimento = @DataNascimento, Ativo = @Ativo
                        WHERE AlunoId = @AlunoId";
            var response = await ExecuteAsync(sql, aluno);

            await _auditoria.RegistrarAsync("Aluno", "UPDATE", aluno);

            return response;
        }

        public async Task<IEnumerable<AlunoDto>> GetMatriculadosPorCursoAsync(int cursoId)
        {
            const string sql = @"
                SELECT 
                    a.AlunoId       AS AlunoId,
                    a.NomeCompleto  AS NomeCompleto,
                    a.Ativo         AS Ativo
                FROM Aluno a
                INNER JOIN AlunoCurso ac ON ac.AlunoId = a.AlunoId
                WHERE ac.CursoId = @CursoId
                  AND a.Ativo = 1
                ORDER BY a.NomeCompleto;";

            var result = await _connection.QueryAsync<AlunoDto>(sql, new { CursoId = cursoId });

            await _auditoria.RegistrarAsync("Aluno", "SELECT_MATRICULADOS", new { CursoId = cursoId });

            return result;
        }
    }
}
