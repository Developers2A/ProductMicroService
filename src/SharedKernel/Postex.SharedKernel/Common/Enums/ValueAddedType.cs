using System.ComponentModel;

namespace Postex.SharedKernel.Common.Enums
{
    public enum ValueAddedType
    {
        [Description("پیامک")] Sms = 1,
        [Description("آواتار")] Avatar = 2,
        [Description("ثبت سفارش")] Submitter = 3,
        [Description("پرینت")] Print = 4,
        [Description("انبار")] Warhousing = 5
    }
}