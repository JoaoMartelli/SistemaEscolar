using SistemaEscolar.Core.Domain.Dtos;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IAlunoCursoService
    {
        Task AdicionarAlunoCurso(AlunoCurso alunoCurso);
    }
}
