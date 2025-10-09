using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class LaboratorioRepository : BaseRepository<Laboratorio>, ILaboratorioRepository
    {
        public async Task<int> AddAsync(Laboratorio laboratorio)
        {
            var sql = @"INSERT INTO Laboratorio (Nome, Capacidade, Tipo, Equipamentos, EscolaId, Ativo)
                        VALUES (@Nome, @Capacidade, @Tipo, @Equipamentos, @EscolaId, @Ativo)";
            return await ExecuteAsync(sql, laboratorio);
        }

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            var sql = "SELECT * FROM Laboratorio WHERE Ativo = 1";
            return await QueryAsync(sql);
        }

        public async Task<int> DeleteAsync(int laboratorioId)
        {
            var sql = "UPDATE Laboratorio SET Ativo = 0 WHERE LaboratorioId = @LaboratorioId";
            return await ExecuteAsync(sql, new { LaboratorioId = laboratorioId });
        }
    }
}