using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface ILaboratorioRepository
    {
        Task<int> AddAsync(Laboratorio laboratorio);
        Task<int> UpdateAsync(Laboratorio laboratorio);
        Task<IEnumerable<Laboratorio>> GetAllAsync();
        Task<int> DeleteAsync(int laboratorioId);
    }
}