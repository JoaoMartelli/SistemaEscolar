using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class LaboratorioRepository : BaseRepository<Laboratorio>, ILaboratorioRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();

        public async Task<int> AddAsync(Laboratorio laboratorio)
        {
            var sql = @"INSERT INTO Laboratorio (Nome, Capacidade, Tipo, Equipamentos, EscolaId, Ativo)
                        VALUES (@Nome, @Capacidade, @Tipo, @Equipamentos, @EscolaId, @Ativo)";
            var response = await ExecuteAsync(sql, laboratorio);

            await _auditoria.RegistrarAsync("Laboratorio", "INSERT", laboratorio);

            return response;
        }

        public async Task<IEnumerable<Laboratorio>> GetAllAsync()
        {
            var sql = "SELECT * FROM Laboratorio WHERE Ativo = 1";
            var result = await QueryAsync(sql);

            //await _auditoria.RegistrarAsync("Laboratorio", "SELECT", null);

            return result;
        }

        public async Task<int> DeleteAsync(int laboratorioId)
        {
            var sql = "UPDATE Laboratorio SET Ativo = 0 WHERE LaboratorioId = @LaboratorioId";
            var response = await ExecuteAsync(sql, new { LaboratorioId = laboratorioId });

            await _auditoria.RegistrarAsync("Laboratorio", "DELETE", new { LaboratorioId = laboratorioId });

            return response;
        }

        public async Task<int> UpdateAsync(Laboratorio laboratorio)
        {
            var sql = @"UPDATE Laboratorio 
                        SET Nome = @Nome, Capacidade = @Capacidade, Tipo = @Tipo, Equipamentos = @Equipamentos, EscolaId = @EscolaId, Ativo = @Ativo
                        WHERE LaboratorioId = @LaboratorioId";
            var response = await ExecuteAsync(sql, laboratorio);

            await _auditoria.RegistrarAsync("Laboratorio", "UPDATE", laboratorio);

            return response;
        }
    }
}