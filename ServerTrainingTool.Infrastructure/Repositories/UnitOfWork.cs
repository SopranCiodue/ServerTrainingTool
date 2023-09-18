using ServerTrainingTool.Application.Contracts;
using ServerTrainingTool.Application.Contracts.Common;
using ServerTrainingTool.Infrastructure.Repositories.Common;
using ServerTrainingTool.Infrastructure.Service;
using System.Collections;

namespace ServerTrainingTool.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrainingToolDbContext _context;

        private Hashtable _repositories;

        //[
        //{Tabella_Corsi, RepositoryTabellaCorsi},
        //{convocazione, RepositoryConvocazione}
        //
        //
        //
        //]

        public UnitOfWork(TrainingToolDbContext context)
        {
            _context = context;
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) {
                _repositories = new Hashtable();        
            }

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type)) {
                //creare
                var typeRepository = typeof(BaseAsyncRepository<>);
                var repositoryInstance = Activator.CreateInstance(typeRepository.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
