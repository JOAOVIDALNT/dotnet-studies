using System.Linq.Expressions;

namespace MyTable_API.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>>? filter = null);
    Task CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task SaveAsync();
}