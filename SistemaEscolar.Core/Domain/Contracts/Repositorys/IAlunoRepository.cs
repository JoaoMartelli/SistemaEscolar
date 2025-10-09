using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface IAlunoRepository
    {
        Task<int> AddAsync(Aluno aluno);
        Task<int> UpdateAsync(Aluno aluno);
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<int> DeleteAsync(int alunoId);
    }
}
