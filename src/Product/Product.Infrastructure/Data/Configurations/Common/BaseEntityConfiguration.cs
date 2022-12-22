﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.SharedKernel.Domain;

namespace Product.Infrastructure.Data.Configurations.Common
{
    public abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase>
      where TBase : BaseEntity<int>
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entity)
        {
            entity.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion();
        }
    }
}