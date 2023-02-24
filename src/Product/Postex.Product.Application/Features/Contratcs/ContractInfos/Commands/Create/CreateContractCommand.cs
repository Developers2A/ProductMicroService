using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Create
{
    public class CreateContractCommand : ITransactionRequest<ContractInfoDto>
    {
        public string ContractNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int? CustomerId { get; set; }
        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }
        public bool IsActive { get; set; }
    }
}
