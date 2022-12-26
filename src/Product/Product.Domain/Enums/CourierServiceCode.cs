using System.ComponentModel;

namespace Product.Domain.Enums
{
    public enum CourierServiceCode
    {
        [Description("همه ")] All = 0,
        [Description("پست پیشتاز")] PostPishtaz = 1,
        [Description("پست سفارشی")] PostSefareshi = 2,
        [Description("پست ویژه")] PostVizhe = 3,
        [Description("چاپار")] Chapar = 4,
        [Description("چاپار اکسپرس")] ChaparExpress = 5,
    }
}