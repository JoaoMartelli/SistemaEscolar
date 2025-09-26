using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetCursosAsync();
        Task AdicionarCurso(Curso curso);
    }
}
