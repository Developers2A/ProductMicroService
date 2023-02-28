using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.Contratcs
{
    public class CodPriceDto
    {
        public int CourierServiceId { get; set; }
        public int ContractId { get; set; }
        public int ContractCodId { get; set; }
        public double ValuePrice { get; set; }
        public double DefaultFixedPercent { get; set; }
        public double DefaultFixedValue { get; set; }
        public double ContractFixedPercent { get; set; }
        public double ContractFixedValue { get; set; }
        public string ContractLevel { get; set; }
    }
}
