using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Update
{
    public class UpdateContractCommand : ITransactionRequest<ContractInfoDto>
    {
        public int Id { get; set; }
        public string ContractNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int ContractTypeId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
