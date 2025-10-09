using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IPresencaService
    {
        Task<IEnumerable<Presenca>> GetPresencasAsync();
        Task AdicionarPresenca(Presenca presenca);
        Task RemoverPresenca(int presencaId);
    }
}