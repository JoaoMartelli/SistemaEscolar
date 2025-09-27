using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class EscolaService : IEscolaService
    {
        public readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task AdicionarEscola(Escola escola)
        {
            if (escola is null)
                throw new ArgumentNullException(nameof(escola));

            if (string.IsNullOrWhiteSpace(escola.Endereco) || string.IsNullOrWhiteSpace(escola.CNPJ)
                || string.IsNullOrWhiteSpace(escola.NomeCompleto) || string.IsNullOrWhiteSpace(escola.UF)
                || string.IsNullOrWhiteSpace(escola.Cidade))
                throw new ArgumentException("Dados da escola incompletos.");

            if (escola.DataInauguracao == DateTime.MinValue || escola.DataInauguracao >= DateTime.Now)
                throw new ArgumentException("Data de inauguração inválida.");

            await _escolaRepository.AddAsync(escola);
        }

        public async Task<IEnumerable<Escola>> GetEscolasAsync()
        {
            return await _escolaRepository.GetAllAsync();
        }
    }
}
