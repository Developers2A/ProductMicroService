using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Infrastructure.Data.Configurations.Common
{
    public abstract class BaseEntityConfiguration<TBase, TKey> : IEntityTypeConfiguration<TBase>
      where TBase : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entity)
        {
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion();

            entity.Property(e => e.CreatedBy)
                .HasDefaultValue(null);

            entity.Property(e => e.ModifiedBy)
                .HasDefaultValue(null);
        }
    }
}