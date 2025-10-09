using SistemaEscolar.Core.Domain.Dtos;
using SistemaEscolar.Core.Domain.Dtos.Presenca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IPresencaService
    {
        Task<IEnumerable<PresencaDto>> GetByCursoDataAsync(int cursoId, DateTime data);
        Task UpsertRangeAsync(IEnumerable<PresencaDto> presencas); // insere/atualiza em lote
    }
}