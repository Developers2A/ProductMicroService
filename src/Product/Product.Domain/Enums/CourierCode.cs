﻿using System.ComponentModel;

namespace Product.Domain.Enums
{
    public enum CourierCode
    {
        [Description("پیک هاب")] Paykhub = 1,
        [Description("کالارسان")] Kalaresan = 2,
        [Description("چاپار")] Chapar = 3,
        [Description("ماهکس")] Mahex = 4,
        [Description("آرامکس")] Aramex = 5,
        [Description("پست")] Post = 6,
        [Description("بین المللی")] International = 7,
        [Description("تعارف")] Taroff = 8,
        [Description("لینک")] Link = 9,
        [Description("پیشروپست")] PishroPost = 10,
        [Description("اسپید")] Speed = 11,
    }
}