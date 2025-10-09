using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class LaboratorioService : ILaboratorioService
    {
        public readonly ILaboratorioRepository _laboratorioRepository;

        public LaboratorioService(ILaboratorioRepository laboratorioRepository)
        {
            _laboratorioRepository = laboratorioRepository;
        }

        public async Task AdicionarLaboratorio(Laboratorio laboratorio)
        {
            if (laboratorio is null)
                throw new ArgumentNullException(nameof(laboratorio));

            if (string.IsNullOrWhiteSpace(laboratorio.Nome) || laboratorio.EscolaId == default)
                throw new ArgumentException("Dados do laboratório incompletos.");

            await _laboratorioRepository.AddAsync(laboratorio);
        }

        public async Task<IEnumerable<Laboratorio>> GetLaboratoriosAsync()
        {
            return await _laboratorioRepository.GetAllAsync();
        }

        public async Task RemoverLaboratorio(int laboratorioId)
        {
            if (laboratorioId <= 0)
                throw new ArgumentException("Id inválido.");
            await _laboratorioRepository.DeleteAsync(laboratorioId);
        }
    }
}