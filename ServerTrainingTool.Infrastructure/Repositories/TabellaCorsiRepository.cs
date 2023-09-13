using Microsoft.EntityFrameworkCore;
using ServerTrainingTool.Application.Contracts;
using ServerTrainingTool.Domain;
using ServerTrainingTool.Infrastructure.Repositories.Common;
using ServerTrainingTool.Infrastructure.Service;

namespace ServerTrainingTool.Infrastructure.Repositories
{
    public class TabellaCorsiRepository : BaseAsyncRepository<Tabella_Corsi>, ITabellaCorsiRepository
    {

        public TabellaCorsiRepository(TrainingToolDbContext context) : base(context) { }

        public async Task<IEnumerable<Tabella_Corsi>> GetCorsiByDocente(string docente)
        {
            return await _context.Tabella_Corsi.Where(x => x.Docente.Contains(docente)).ToListAsync();
        }
    }
}
