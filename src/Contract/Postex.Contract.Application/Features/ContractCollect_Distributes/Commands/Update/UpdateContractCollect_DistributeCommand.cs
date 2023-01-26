using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCollect_Distributes.Command.Update
{
    public class UpdateContractCollect_DistributeCommand : ITransactionRequest
    {
        public int Id { get; set; }    
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int BoxTypeId { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActice { get; set; }
    }
}
