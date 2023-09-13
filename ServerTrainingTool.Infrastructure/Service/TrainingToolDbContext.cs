using Microsoft.EntityFrameworkCore;
using ServerTrainingTool.Domain;

namespace ServerTrainingTool.Infrastructure.Service
{
    public class TrainingToolDbContext : DbContext
    {
        public TrainingToolDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Tabella_Corsi> Tabella_Corsi { get; set; }
    }
}
