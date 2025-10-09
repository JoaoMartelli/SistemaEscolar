using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface IPresencaRepository
    {
        Task<int> AddAsync(Presenca presenca);
        Task<IEnumerable<Presenca>> GetAllAsync();
        Task<int> DeleteAsync(int presencaId);
    }
}