using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractInfos.Commands.Update
{
    public class UpdateContractCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string ContractNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ContractTypeId { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
    }
}
