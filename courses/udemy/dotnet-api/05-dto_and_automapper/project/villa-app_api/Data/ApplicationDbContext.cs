using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using villa_app_api.Models;

namespace villa_app_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        

        public DbSet<Villa> Villas {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Acapulco",
                    Details = "Lugar incrível",
                    Rate = 10,
                    Sqft = 10,
                    Occupancy = 10,
                    ImageUrl = "",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Name = "Campos do Jordão",
                    Details = "Frio demaize",
                    Rate = 10,
                    Sqft = 10,
                    Occupancy = 10,
                    ImageUrl = "",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa
                {
                    Id = 3,
                    Name = "Beach Park",
                    Details = "Molhado",
                    Rate = 10,
                    Sqft = 10,
                    Occupancy = 10,
                    ImageUrl = "",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
                );
        }

    }
}