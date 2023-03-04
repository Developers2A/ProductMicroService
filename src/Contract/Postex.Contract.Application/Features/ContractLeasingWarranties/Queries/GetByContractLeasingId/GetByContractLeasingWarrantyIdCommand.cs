using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractLeasingWarranties.Queries.GetByContractLeasingId
{
    public class GetByContractLeasingWarrantyIdCommand : IRequest<ContractLeasingWarrantyDto>
    {
        public int ContractLeasingId { get; set; }
    }
}
