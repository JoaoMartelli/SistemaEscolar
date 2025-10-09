using Dapper;
using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
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

        public async Task<int> UpdateAsync(Aluno aluno)
        {
            var sql = @"UPDATE Aluno 
                        SET NomeCompleto = @NomeCompleto, CPF = @CPF, Endereco = @Endereco, 
                            Cidade = @Cidade, UF = @UF, DataNascimento = @DataNascimento, Ativo = @Ativo
                        WHERE AlunoId = @AlunoId";
            return await ExecuteAsync(sql, aluno);
        }


        public async Task<IEnumerable<AlunoDto>> GetMatriculadosPorCursoAsync(int cursoId)
        {
            const string sql = @"
                SELECT 
                    a.AlunoId       AS AlunoId,
                    a.NomeCompleto  AS NomeCompleto,
                    a.Ativo         AS Ativo
                FROM Aluno a
                INNER JOIN AlunoCurso ac ON ac.AlunoId = a.AlunoId
                WHERE ac.CursoId = @CursoId
                  AND a.Ativo = 1
                ORDER BY a.NomeCompleto;";

            // Aqui usamos _connection direto para mapear em AlunoDto (tipo diferente do T do BaseRepository)
            return await _connection.QueryAsync<AlunoDto>(sql, new { CursoId = cursoId });
        }
    }
}
