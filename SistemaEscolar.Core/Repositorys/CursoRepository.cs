using SistemaEscolar.Core.Domain.Contracts.Repositorys;
using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Repositorys.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Repositorys
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public async Task<int> AddAsync(Curso curso)
        {
            var sql = @"INSERT INTO Curso (Nome, CargaHoraria, Instrutor, EscolaId, Ativo)
                        VALUES (@Nome, @CargaHoraria, @Instrutor, @EscolaId, @Ativo)";
            return await ExecuteAsync(sql, curso);
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            var sql = "SELECT * FROM Curso WHERE Ativo = 1";
            return await QueryAsync(sql);
        }
    }
}
