using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface IAlunoCursoRepository
    {
        Task<int> AddAsync(AlunoCurso alunoCurso);
        Task<IEnumerable<AlunoCurso>> GetAllAsync(AlunoCurso alunoCurso);
    }
}
