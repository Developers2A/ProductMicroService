using Postex.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Domain
{
    public class ContractAccountingTemplate : BaseEntity<int>
    {
        public int ContractInfoId { get; set; }
        public ContractInfo ContractInfo { get; set; }
        public string ContractDetailType { get; set; }
        public int ContractDetailId { get; set; }
        public int CustomerId { get; set; }
        public double PercentValue { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
