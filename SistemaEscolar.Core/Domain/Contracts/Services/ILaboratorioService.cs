using SistemaEscolar.Core.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Domain.Contracts.Services
{
    public interface ILaboratorioService
    {
        Task<IEnumerable<Laboratorio>> GetLaboratoriosAsync();
        Task AdicionarLaboratorio(Laboratorio laboratorio);
        Task RemoverLaboratorio(int laboratorioId);
    }
}