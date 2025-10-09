using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class EscolaRepository : BaseRepository<Escola>, IEscolaRepository
    {
        public async Task<int> AddAsync(Escola escola)
        {
            var sql = @"INSERT INTO Escola (NomeCompleto, CNPJ, Endereco, Cidade, UF, DataInauguracao)
                        VALUES (@NomeCompleto, @CNPJ, @Endereco, @Cidade, @UF, @DataInauguracao)";
            return await ExecuteAsync(sql, escola);
        }

        public async Task<IEnumerable<Escola>> GetAllAsync()
        {
            var sql = "SELECT * FROM Escola";
            return await QueryAsync(sql);
        }

        public async Task<int> DeleteAsync(int escolaId)
        {
            var sql = "DELETE FROM Escola WHERE EscolaId = @EscolaId";
            return await ExecuteAsync(sql, new { EscolaId = escolaId });
        }
    }
}
