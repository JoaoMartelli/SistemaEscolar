    using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class PresencaService : IPresencaService
    {
        public readonly IPresencaRepository _presencaRepository;

        public PresencaService(IPresencaRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        public async Task<IEnumerable<PresencaDto>> GetByCursoDataAsync(int cursoId, DateTime data)
        {
            if (cursoId <= 0)
                throw new ArgumentException("CursoId inválido.");
            if (data == null)
                throw new ArgumentException("Data inválido.");

            return await _presencaRepository.GetByCursoDataAsync(cursoId, data);
        }

        public async Task UpsertRangeAsync(IEnumerable<PresencaDto> presencas)
        {
            if (presencas == null)
                throw new ArgumentNullException(nameof(presencas));

            foreach (var p in presencas)
            {
                if (p.CursoId <= 0)
                    throw new ArgumentException("CursoId inválido.");
                if (p.AlunoId <= 0)
                    throw new ArgumentException("AlunoId inválido.");
                if (p.DataPresenca == DateTime.MinValue)
                    throw new ArgumentException("DataPresenca inválida.");
            }
            await _presencaRepository.UpsertRangeAsync(presencas);
        }
    }
}