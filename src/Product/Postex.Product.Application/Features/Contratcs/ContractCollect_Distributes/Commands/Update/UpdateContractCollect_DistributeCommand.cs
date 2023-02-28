using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Update
{
    public class UpdateContractCollect_DistributeCommand : ITransactionRequest<ContractCollectionDistributionDto>
    {
        public int Id { get; set; }
        public int CourierServiceId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int BoxTypeId { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActice { get; set; }
    }
}
