using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItems.Commands.UpdateContractItem
{
    public class UpdateContractItemCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int ContractItemTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
    }
}
