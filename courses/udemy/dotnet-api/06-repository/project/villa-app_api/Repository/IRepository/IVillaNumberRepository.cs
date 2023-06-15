using System.Linq.Expressions;
using villa_app_api.Models;

namespace villa_app_api.Repository.IRepository
{
    public interface IVillaNumberRepository :IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
