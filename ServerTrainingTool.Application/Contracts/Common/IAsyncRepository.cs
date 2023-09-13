using System.Linq.Expressions;

namespace ServerTrainingTool.Application.Contracts.Common
{
    public interface IAsyncRepository<T> where T : class
    {
        //Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, string includeString = null, bool disabledTracking = true);

    }
}
