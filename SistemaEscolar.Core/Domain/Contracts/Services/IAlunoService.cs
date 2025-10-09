using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunosAsync();
        Task AdicionarAluno(Aluno aluno);
        Task RemoverAluno(int alunoId);
        Task AtualizarAluno(Aluno aluno);
    }
}
