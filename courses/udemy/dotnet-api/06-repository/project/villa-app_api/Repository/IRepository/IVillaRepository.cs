using System.Linq.Expressions;
using villa_app_api.Models;

namespace villa_app_api.Repository.IRepository
{
    public interface IVillaRepository :IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
