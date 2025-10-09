using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Repositorys
{
    public interface IPresencaRepository
    {
        Task<IEnumerable<PresencaDto>> GetByCursoDataAsync(int cursoId, DateTime data);
        Task UpsertRangeAsync(IEnumerable<PresencaDto> presencas); // transação interna
    }
}