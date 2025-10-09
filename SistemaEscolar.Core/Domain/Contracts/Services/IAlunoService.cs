using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunosAsync();
        Task AdicionarAluno(Aluno aluno);
        Task AtualizarAluno(Aluno aluno);
        Task<IEnumerable<AlunoDto>> GetMatriculadosPorCursoAsync(int cursoId);
    }
}
