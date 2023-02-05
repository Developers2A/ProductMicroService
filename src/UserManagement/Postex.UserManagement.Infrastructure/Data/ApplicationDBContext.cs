using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Domain;
using ProductService.Domain.Users;

namespace Postex.UserManagement.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is not IAuditable<Guid>)
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["CreatedOn"] = DateTime.Now;
                        entry.CurrentValues["ModifiedOn"] = null;
                        break;

                    case EntityState.Modified:
                        entry.CurrentValues["CreatedOn"] = entry.OriginalValues["CreatedOn"];
                        entry.CurrentValues["ModifiedOn"] = DateTime.Now;
                        break;
                }
            }

            var entiries = await base.SaveChangesAsync(cancellationToken);

            return entiries;
        }
    }
}
