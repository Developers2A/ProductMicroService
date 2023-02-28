using System.ComponentModel;

namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Enums
{
    public enum PaymentMethod
    {

        [Description("پرداخت در محل")]
        Cod = 1212,
        [Description("پرداخت آنلاین")]
        OnlinePayment = 1213,
        [Description("ارسال رایگان")]
        FreeShipping = 1214
    }
}