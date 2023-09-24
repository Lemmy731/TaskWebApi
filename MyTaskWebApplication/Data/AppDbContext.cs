using Microsoft.EntityFrameworkCore;
using MyTaskWebDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebApplication.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryDetailEntity>().HasKey(x => new
            {
                x.Id
            }
            );
            modelBuilder.Entity<CountryDetailEntity>().HasOne(x => x.Country).WithMany(x => x.CountryDetails).HasForeignKey(x => x.CountryId);
        }
        public DbSet<CountryEntity> Countries { get; set; }  
        public DbSet<CountryDetailEntity> CountryDetails { get; set; }    
    }
}
