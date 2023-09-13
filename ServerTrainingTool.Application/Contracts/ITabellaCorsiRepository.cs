using ServerTrainingTool.Application.Contracts.Common;
using ServerTrainingTool.Domain;

namespace ServerTrainingTool.Application.Contracts
{
    public interface ITabellaCorsiRepository :IAsyncRepository<Tabella_Corsi> 
    {
        Task<IEnumerable<Tabella_Corsi>> GetCorsiByDocente(string docente);
    }
}
