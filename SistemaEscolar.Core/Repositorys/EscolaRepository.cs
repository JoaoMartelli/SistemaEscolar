using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class EscolaRepository : BaseRepository<Escola>, IEscolaRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();

        public async Task<int> AddAsync(Escola escola)
        {
            var sql = @"INSERT INTO Escola (NomeCompleto, CNPJ, Endereco, Cidade, UF, DataInauguracao)
                        VALUES (@NomeCompleto, @CNPJ, @Endereco, @Cidade, @UF, @DataInauguracao)";
            var response = await ExecuteAsync(sql, escola);

            await _auditoria.RegistrarAsync("Escola", "INSERT", escola);

            return response;
        }

        public async Task<IEnumerable<Escola>> GetAllAsync()
        {
            var sql = "SELECT * FROM Escola WHERE Ativo = 1";
            var result = await QueryAsync(sql);

            //await _auditoria.RegistrarAsync("Escola", "SELECT", null);

            return result;
        }

        public async Task<int> DeleteAsync(int escolaId)
        {
            var sql = "DELETE FROM Escola WHERE EscolaId = @EscolaId";
            var response = await ExecuteAsync(sql, new { EscolaId = escolaId });

            await _auditoria.RegistrarAsync("Escola", "DELETE", new { EscolaId = escolaId });

            return response;
        }

        public async Task<int> UpdateAsync(Escola escola)
        {
            var sql = @"UPDATE Escola 
                        SET NomeCompleto = @NomeCompleto, 
                            CNPJ = @CNPJ, 
                            Endereco = @Endereco, 
                            Cidade = @Cidade, 
                            UF = @UF, 
                            DataInauguracao = @DataInauguracao, 
                            Ativo = @Ativo
                        WHERE EscolaId = @EscolaId";
            var response = await ExecuteAsync(sql, escola);

            await _auditoria.RegistrarAsync("Escola", "UPDATE", escola);

            return response;
        }
    }
}
