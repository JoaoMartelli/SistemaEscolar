using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using SistemaEscolar.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        private readonly AuditoriaNoSqlService _auditoria = new AuditoriaNoSqlService();

        public async Task<int> AddAsync(Curso curso)
        {
            var sql = @"INSERT INTO Curso (Nome, CargaHoraria, Instrutor, EscolaId, Ativo)
                        VALUES (@Nome, @CargaHoraria, @Instrutor, @EscolaId, @Ativo)";
            var response = await ExecuteAsync(sql, curso);

            await _auditoria.RegistrarAsync("Curso", "INSERT", curso);

            return response;
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            var sql = "SELECT * FROM Curso WHERE Ativo = 1";
            var result = await QueryAsync(sql);

            //await _auditoria.RegistrarAsync("Curso", "SELECT", null);

            return result;
        }

        public async Task<int> DeleteAsync(int cursoId)
        {
            var sql = "UPDATE Curso SET Ativo = 0 WHERE CursoId = @CursoId";
            var response = await ExecuteAsync(sql, new { CursoId = cursoId });

            await _auditoria.RegistrarAsync("Curso", "DELETE", new { CursoId = cursoId });

            return response;
        }

        public async Task<int> UpdateAsync(Curso curso)
        {
            var sql = @"UPDATE Curso 
                        SET Nome = @Nome, 
                            CargaHoraria = @CargaHoraria, 
                            Instrutor = @Instrutor, 
                            EscolaId = @EscolaId, 
                            Ativo = @Ativo 
                        WHERE CursoId = @CursoId";
            var response = await ExecuteAsync(sql, curso);

            await _auditoria.RegistrarAsync("Curso", "UPDATE", curso);

            return response;
        }
    }
}
