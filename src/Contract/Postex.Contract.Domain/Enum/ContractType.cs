using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Domain.Enums
{
    public enum ContractType
    {
        [Description("قرارداد پیش فرض")]
        Default = 1,
        [Description("قرارداد مشتری")]
        Customer = 2,
        [Description("قرارداد نماینده")]
        Agent = 3,
        [Description("قرارداد شهر")]
        City = 4
    }
}
