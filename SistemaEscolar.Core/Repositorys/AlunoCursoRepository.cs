using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class AlunoCursoRepository : BaseRepository<AlunoCurso>, IAlunoCursoRepository
    {
        public async Task<int> AddAsync(AlunoCurso alunoCurso)
        {
            var sql = @"INSERT INTO AlunoCurso (AlunoId, CursoId, DataMatricula) 
                        VALUES (@AlunoId, @CursoId, @DataMatricula)";
            return await ExecuteAsync(sql, alunoCurso);
        }

        public async Task<IEnumerable<AlunoCurso>> GetAllAsync(AlunoCurso alunoCurso)
        {
            var sql = "SELECT * FROM AlunoCurso WHERE AlunoId = @AlunoId AND CursoId = @CursoId";
            return await QueryAsync(sql, alunoCurso);
        }
    }
}
