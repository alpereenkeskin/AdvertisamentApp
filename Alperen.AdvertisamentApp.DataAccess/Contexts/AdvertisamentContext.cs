using Alperen.AdvertisamentApp.DataAccess.Configurations;
using Alperen.AdvertisamentApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.DataAccess.Contexts
{
    public class AdvertisamentContext : DbContext
    {
        public AdvertisamentContext(DbContextOptions<AdvertisamentContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisamentConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisamentUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisamentUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderServiceConfiguration());


        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Advertisament> Advertisaments { get; set; }
        public DbSet<AdvertisamentUserStatus> AdvertisamentUserStatuses { get; set; }
        public DbSet<AdvertisamentUser> AdvertisamentUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
    }
}
