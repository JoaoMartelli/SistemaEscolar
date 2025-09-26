using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface IEscolaService
    {
        Task<IEnumerable<Escola>> GetEscolasAsync();
        Task AdicionarEscola(Escola escola);
    }
}
