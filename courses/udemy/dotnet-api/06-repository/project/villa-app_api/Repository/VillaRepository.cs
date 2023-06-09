using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using villa_app_api.Data;
using villa_app_api.Models;
using villa_app_api.Repository.IRepository;

namespace villa_app_api.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {

        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
