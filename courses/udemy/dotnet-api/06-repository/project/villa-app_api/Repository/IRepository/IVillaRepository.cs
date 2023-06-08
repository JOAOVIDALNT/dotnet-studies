using System.Linq.Expressions;
using villa_app_api.Models;

namespace villa_app_api.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null);
        Task<List<Villa>> GetAsync(Expression<Func<Villa, bool>> filter = null, bool tracked = true);

        Task CreateAsync(Villa entity);

        Task DeleteAsync(Villa entity);
        Task SaveAsync();

    }
}
