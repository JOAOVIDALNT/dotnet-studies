using System.Linq.Expressions;
using villa_app_api.Models;

namespace villa_app_api.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
