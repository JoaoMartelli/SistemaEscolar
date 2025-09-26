using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class CursoService : ICursoService
    {
        public readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task AdicionarCurso(Curso curso)
        {
            if (curso is null)
                throw new ArgumentNullException(nameof(curso));

            if (string.IsNullOrWhiteSpace(curso.Nome) || string.IsNullOrWhiteSpace(curso.Instrutor)
                || curso.EscolaId == default || curso.CargaHoraria == default)
                throw new ArgumentException("Dados do curso incompletos.");

            await _cursoRepository.AddAsync(curso);
        }

        public async Task<IEnumerable<Curso>> GetCursosAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }
    }
}
