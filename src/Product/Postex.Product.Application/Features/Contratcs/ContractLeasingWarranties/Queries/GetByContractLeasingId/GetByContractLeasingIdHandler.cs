using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractLeasingWarranties.Queries.GetById
{
    public class GetByContractLeasingIdHandler : IRequestHandler<GetByContractLeasingIdCommand, ContractLeasingWarrantyDto>
    {
        private readonly IReadRepository<ContractLeasingWarranty> readRepository;

        public GetByContractLeasingIdHandler(IReadRepository<ContractLeasingWarranty> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<ContractLeasingWarrantyDto> Handle(GetByContractLeasingIdCommand request, CancellationToken cancellationToken)
        {
            var leasing = await readRepository.Table
                .Select(c => new ContractLeasingWarrantyDto
                {
                    Id = c.Id,                   
                    ContractLeasingId = c.ContractLeasingId,
                    WarrantyAmount=c.WarrantyAmount,
                    WarrantyEndDate=c.WarrantyEndDate,
                    WarrantyReqistrationDate=c.WarrantyReqistrationDate,
                    Description=c.Description,
                    BankName=c.BankName,    
                    WarrantyNo=c.WarrantyNo,
                   
                })
                .Where(c=> c.ContractLeasingId == request.ContractLeasingId)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
