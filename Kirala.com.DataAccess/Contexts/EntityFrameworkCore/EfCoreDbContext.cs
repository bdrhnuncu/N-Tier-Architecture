using Kirala.com.DataAccess.Configuration;
using Kirala.com.DataAccess.Mapping;
using Kirala.com.Entities.Abstract;
using Kirala.com.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Contexts.EntityFrameworkCore
{
    public class EfCoreDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AutoMobile> AutoMobiles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<WheelDrive> WheelDrives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseSqlServer(ConfigureConnString.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AutoMobile>().ToTable("AutoMobileAdverts");//for Table Per Type

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdvertMapping).Assembly);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var users = ChangeTracker.Entries<User>();

            foreach (var user in users)
            {
                if (user.State == EntityState.Added)
                {
                    user.Entity.Created = DateTime.Now;
                }
            }

            var autoMobiles = ChangeTracker.Entries<AutoMobile>();

            foreach (var autoMobile in autoMobiles)
            {
                if (autoMobile.State == EntityState.Added)
                {
                    autoMobile.Entity.Created = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
