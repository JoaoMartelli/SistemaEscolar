using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface IEscolaRepository
    {
        Task<int> AddAsync(Escola aluno);
        Task<IEnumerable<Escola>> GetAllAsync();
    }
}
