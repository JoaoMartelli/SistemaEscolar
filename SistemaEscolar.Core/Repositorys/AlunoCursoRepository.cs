using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class AlunoCursoRepository : BaseRepository<AlunoCurso>, IAlunoCursoRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();
        public async Task<int> AddAsync(AlunoCurso alunoCurso)
        {
            var sql = @"INSERT INTO AlunoCurso (AlunoId, CursoId, DataMatricula) 
                        VALUES (@AlunoId, @CursoId, @DataMatricula)";
            var response = await ExecuteAsync(sql, alunoCurso);

            await _auditoria.RegistrarAsync("AlunoCurso", "INSERT", alunoCurso);

            return response;
        }

        public async Task<IEnumerable<AlunoCurso>> GetAllAsync(AlunoCurso alunoCurso)
        {
            var sql = "SELECT * FROM AlunoCurso WHERE AlunoId = @AlunoId AND CursoId = @CursoId";
            var result = await QueryAsync(sql, alunoCurso);

            await _auditoria.RegistrarAsync("AlunoCurso", "SELECT", alunoCurso);

            return result;
        }
    }
}
