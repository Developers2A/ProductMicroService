using Postex.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Domain
{
    public class ContractCourier : BaseEntity<int>
    {
        public ContractInfo ContractInfo { get; set; }
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

    }
}
