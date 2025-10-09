using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Contracts.Services;
using SistemaEscolar.Core.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class AlunoService : IAlunoService
    {
        public readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            if (aluno is null)
                throw new ArgumentNullException(nameof(aluno));

            if (string.IsNullOrWhiteSpace(aluno.Endereco) || string.IsNullOrWhiteSpace(aluno.UF)
                || string.IsNullOrWhiteSpace(aluno.NomeCompleto) || string.IsNullOrWhiteSpace(aluno.CPF)
                || string.IsNullOrWhiteSpace(aluno.Cidade))
                throw new ArgumentException("Dados do aluno incompletos.");

            if (aluno.DataNascimento == DateTime.MinValue || aluno.DataNascimento >= DateTime.Now)
                throw new ArgumentException("Data de nascimento inválida.");

            await _alunoRepository.AddAsync(aluno);
        }
        public async Task AtualizarAluno(Aluno aluno)
        {
            if (aluno is null)
                throw new ArgumentNullException(nameof(aluno));

            if (string.IsNullOrWhiteSpace(aluno.Endereco) || string.IsNullOrWhiteSpace(aluno.UF)
                || string.IsNullOrWhiteSpace(aluno.NomeCompleto) || string.IsNullOrWhiteSpace(aluno.CPF)
                || string.IsNullOrWhiteSpace(aluno.Cidade))
                throw new ArgumentException("Dados do aluno incompletos.");

            if (aluno.DataNascimento == DateTime.MinValue || aluno.DataNascimento >= DateTime.Now)
                throw new ArgumentException("Data de nascimento inválida.");

            await _alunoRepository.UpdateAsync(aluno);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            return await _alunoRepository.GetAllAsync();
        }

        public async Task RemoverAluno(int alunoId)
        {
            if (alunoId <= 0)
                throw new ArgumentException("Id inválido.");
            await _alunoRepository.DeleteAsync(alunoId);
        }
    }
}
