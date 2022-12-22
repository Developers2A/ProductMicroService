using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Couriers;
using Product.Domain.Locations;
using Product.Domain.Posts;
using Product.Domain.Users;
using Product.Domain.ValueAddedPrices;

namespace Product.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<CourierService> Couriers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<CourierCityMapping> CourierCityMappings { get; set; }
        public virtual DbSet<CourierStatusMapping> CourierStatusMappings { get; set; }
        public virtual DbSet<PostShop> PostShops { get; set; }
        public virtual DbSet<ValueAddedPrice> ValueAddedPrices { get; set; }
        public virtual DbSet<CourierCityType> CourierCityTypes { get; set; }
        public virtual DbSet<CourierCityTypePrice> CourierCityTypePrices { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
