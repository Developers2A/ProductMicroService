using System.ComponentModel;

namespace Product.Domain.Enums
{
    public enum ServiceType
    {
        [Description("جمع آوری و توزیع")] DistributionAndCollectionPaykhub = 1,
        [Description("جمع آوری ")] CollectionForMiddleMileDelivery = 2,
        [Description("توزیع")] Distribution = 3
    }
}