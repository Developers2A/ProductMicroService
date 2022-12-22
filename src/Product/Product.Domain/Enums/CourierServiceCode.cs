using System.ComponentModel;

namespace Product.Domain.Enums
{
    public enum CourierServiceCode
    {
        [Description("همه ")] All = 0,
        [Description("پست پیشتاز")] PostPishtaz = 1,
        [Description("پست ویژه")] PostVizhe = 2,
    }
}