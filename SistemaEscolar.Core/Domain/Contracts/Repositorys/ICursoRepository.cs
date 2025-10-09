using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface ICursoRepository
    {
        Task<int> AddAsync(Curso curso);
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<int> DeleteAsync(int cursoId);
    }
}
