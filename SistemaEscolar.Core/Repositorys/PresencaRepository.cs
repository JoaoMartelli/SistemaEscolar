using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class PresencaRepository : BaseRepository<Presenca>, IPresencaRepository
    {
        public async Task<int> AddAsync(Presenca presenca)
        {
            var sql = @"INSERT INTO Presenca (CursoID, AlunoID, DataPresenca, StatusPresenca, Justificativa, Ativo)
                        VALUES (@CursoId, @AlunoId, @DataPresenca, @StatusPresenca, @Justificativa, @Ativo)";
            return await ExecuteAsync(sql, presenca);
        }

        public async Task<IEnumerable<Presenca>> GetAllAsync()
        {
            var sql = "SELECT * FROM Presenca WHERE Ativo = 1";
            return await QueryAsync(sql);
        }

        public async Task<int> DeleteAsync(int presencaId)
        {
            var sql = "UPDATE Presenca SET Ativo = 0 WHERE PresencaId = @PresencaId";
            return await ExecuteAsync(sql, new { PresencaId = presencaId });
        }
    }
}