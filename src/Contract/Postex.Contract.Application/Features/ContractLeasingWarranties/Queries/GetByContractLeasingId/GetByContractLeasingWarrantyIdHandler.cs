using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractLeasingWarranties.Queries.GetByContractLeasingId
{
    public class GetByContractLeasingWarrantyIdHandler : IRequestHandler<GetByContractLeasingWarrantyIdCommand, ContractLeasingWarrantyDto>
    {
        private readonly IReadRepository<ContractLeasingWarranty> readRepository;

        public GetByContractLeasingWarrantyIdHandler(IReadRepository<ContractLeasingWarranty> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<ContractLeasingWarrantyDto> Handle(GetByContractLeasingWarrantyIdCommand request, CancellationToken cancellationToken)
        {
            var leasing = await readRepository.Table
                .Select(c => new ContractLeasingWarrantyDto
                {
                    Id = c.Id,
                    ContractLeasingId = c.ContractLeasingId,
                    WarrantyAmount = c.WarrantyAmount,
                    WarrantyEndDate = c.WarrantyEndDate,
                    WarrantyReqistrationDate = c.WarrantyReqistrationDate,
                    Description = c.Description,
                    BankName = c.BankName,
                    WarrantyNo = c.WarrantyNo,

                })
                .Where(c => c.ContractLeasingId == request.ContractLeasingId)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
