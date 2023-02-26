using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ValueAddedPriceDto
    {
        public int ValueAddedTypeId { get; set; }
        public int ContractId { get; set; }
        public int ContractValueAddedId { get; set; }
        public double DefaultSalePrice { get; set; }
        public double DefaultBuyPrice { get; set; }
        public double ContractSalePrice { get; set; }
        public double ContractBuyPrice { get; set; }
        public string ContractLevel { get; set; }

    }
}
