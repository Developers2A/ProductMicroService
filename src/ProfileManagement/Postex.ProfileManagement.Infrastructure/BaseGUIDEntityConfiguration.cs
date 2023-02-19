using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.SharedKernel.Domain;

namespace Postex.ProfileManagement.Infrastructure
{
    public abstract class BaseGUIDEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase>
       where TBase : BaseEntity<Guid> 
         
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entity)
        {
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion();

            //entity.Property(e => e.CreatedBy)
            //    .HasDefaultValue(0);

            //entity.Property(e => e.ModifiedBy)
            //    .HasDefaultValue(0);
        }
    }
}
