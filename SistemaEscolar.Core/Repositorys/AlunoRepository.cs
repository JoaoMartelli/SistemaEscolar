using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public async Task<int> AddAsync(Aluno aluno)
        {
            var sql = @"INSERT INTO Aluno (NomeCompleto, CPF, Endereco, Cidade, UF, DataNascimento, Ativo) 
                        VALUES (@NomeCompleto, @CPF, @Endereco, @Cidade, @UF, @DataNascimento, @Ativo)";
            return await ExecuteAsync(sql, aluno);
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            var sql = "SELECT * FROM Aluno WHERE Ativo = 1";
            return await QueryAsync(sql);
        }

        public async Task<int> DeleteAsync(int alunoId)
        {
            var sql = "UPDATE Aluno SET Ativo = 0 WHERE AlunoId = @AlunoId";
            return await ExecuteAsync(sql, new { AlunoId = alunoId });
        }

        public async Task<int> UpdateAsync(Aluno aluno)
        {
            var sql = @"UPDATE Aluno 
                        SET NomeCompleto = @NomeCompleto, CPF = @CPF, Endereco = @Endereco, 
                            Cidade = @Cidade, UF = @UF, DataNascimento = @DataNascimento, Ativo = @Ativo
                        WHERE AlunoId = @AlunoId";
            return await ExecuteAsync(sql, aluno);
        }
    }
}
