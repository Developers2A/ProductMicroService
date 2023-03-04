﻿using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Domain;

namespace Postex.Notification.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity<int> || entry.Entity is not BaseEntity<Guid>)
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
