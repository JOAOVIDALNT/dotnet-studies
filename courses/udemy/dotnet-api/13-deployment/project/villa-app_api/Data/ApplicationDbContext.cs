using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using villa_app_api.Models.Entities;

namespace villa_app_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // AO INVÉS DE APENNAS DbContext, COM O .NET IDENTITY UTILIZAMOS O IDENTITY E INFORMAMOS A CLASSE DO USUÁRIO
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Villa> Villas {get; set;}
        public DbSet<VillaNumber> VillaNumbers{ get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // AJUDA A CRIAR OS KEYMAPPINGS QUE PRECISAMOS PARA OS USERS
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