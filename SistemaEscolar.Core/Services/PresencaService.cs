    using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
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

        public async Task AdicionarPresenca(Presenca presenca)
        {
            if (presenca is null)
                throw new ArgumentNullException(nameof(presenca));

            if (presenca.CursoId == default || presenca.AlunoId == default || presenca.DataPresenca == default
                || string.IsNullOrWhiteSpace(presenca.StatusPresenca))
                throw new ArgumentException("Dados da presença incompletos.");

            await _presencaRepository.AddAsync(presenca);
        }

        public async Task<IEnumerable<Presenca>> GetPresencasAsync()
        {
            return await _presencaRepository.GetAllAsync();
        }

        public async Task RemoverPresenca(int presencaId)
        {
            if (presencaId <= 0)
                throw new ArgumentException("Id inválido.");
            await _presencaRepository.DeleteAsync(presencaId);
        }
    }
}