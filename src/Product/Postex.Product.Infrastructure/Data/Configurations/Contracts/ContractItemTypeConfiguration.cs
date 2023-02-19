using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postex.Product.Domain;
using Postex.Product.Infrastructure.Data.Configurations.Common;

namespace Postex.Product.Infrastructure.Data.Configurations
{
    public class ContractItemTypeConfiguration : BaseEntityConfiguration<ContractItemType>
    {
        public override void Configure(EntityTypeBuilder<ContractItemType> entity)
        {
            base.Configure(entity);
            entity.ToTable("cn_ContractItemTypes");
            entity.Property(c => c.ContractTypeName)
                .HasMaxLength(128);
            entity.Property(c => c.ContractTypeCode)
                .HasMaxLength(10);
            entity.HasData(Seed());

        }

        private static object[] Seed()
        {
            var createDate = new DateTime(2022, 12, 12, 12, 12, 0);
            return new object[]
            {
                new ContractItemType {
                    Id = 1,
                     ContractTypeCode = "01",
                     ContractTypeName="پیام کوتاه",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                   new ContractItemType
                {
                     Id = 2,
                     ContractTypeCode = "02",
                     ContractTypeName="چاپ فاکتور",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new ContractItemType
                {
                     Id = 3,
                     ContractTypeCode = "03",
                     ContractTypeName="آواتار",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
                new ContractItemType
                {
                     Id = 4,
                     ContractTypeCode = "04",
                     ContractTypeName="انبار",
                    IsRemoved = false,
                    CreatedOn = createDate
                },
              
            };
        }
    }
}
