using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class AlunoCursoService : IAlunoCursoService
    {
        public readonly IAlunoCursoRepository _alunoCursoRepository;

        public AlunoCursoService(IAlunoCursoRepository alunoCursoRepository)
        {
            _alunoCursoRepository = alunoCursoRepository;
        }

        public async Task AdicionarAlunoCurso(AlunoCurso alunoCurso)
        {
            if (alunoCurso is null)
                throw new ArgumentNullException(nameof(alunoCurso));

            if (alunoCurso.AlunoId == 0 || alunoCurso.CursoId == 0)
                throw new ArgumentException("Dados do AlunoCurso incompletos.");

            var alunoCursos = await _alunoCursoRepository.GetAllAsync(alunoCurso);

            if (alunoCursos.Any())
                throw new InvalidOperationException("O aluno já está matriculado neste curso.");

            await _alunoCursoRepository.AddAsync(alunoCurso);
        }
    }
}
