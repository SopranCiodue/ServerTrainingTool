using Microsoft.EntityFrameworkCore;
using ServerTrainingTool.Application.Contracts.Common;
using ServerTrainingTool.Infrastructure.Service;
using System.Linq.Expressions;

namespace ServerTrainingTool.Infrastructure.Repositories.Common
{
    public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TrainingToolDbContext _context;

        public BaseAsyncRepository(TrainingToolDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, string includeString = null, bool disabledTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disabledTracking) {
                query = query.AsNoTracking();
            }
            if (!string.IsNullOrWhiteSpace(includeString)) {
                query = query.Include(includeString);
            }
            if (predicate != null) { 
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }
    }
}
