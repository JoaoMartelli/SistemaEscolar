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
            var sql = "SELECT * FROM Aluno";
            return await QueryAsync(sql);
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Aluno WHERE AlunoId = @Id";
            return await QueryFirstOrDefaultAsync(sql, new { Id = id });
        }

        public async Task<int> UpdateAsync(Aluno aluno)
        {
            var sql = @"UPDATE Aluno SET NomeCompleto=@NomeCompleto, CPF=@CPF, Endereco=@Endereco, 
                        Cidade=@Cidade, UF=@UF, DataNascimento=@DataNascimento, Ativo=@Ativo 
                        WHERE AlunoId=@AlunoId";
            return await ExecuteAsync(sql, aluno);
        }

        public async Task<int> RemoveAsync(int id)
        {
            var sql = "DELETE FROM Aluno WHERE AlunoId=@Id";
            return await ExecuteAsync(sql, new { Id = id });
        }
    }
}
