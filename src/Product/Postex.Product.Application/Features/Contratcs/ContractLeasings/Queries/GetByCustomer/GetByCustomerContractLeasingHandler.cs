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

namespace Postex.Product.Application.Features.ContractLeasings.Queries.GetByCustomer
{
    public class GetByCustomerContractLeasingHandler : IRequestHandler<GetByCustomerContractLeasingCommand, ContractLeasingDto>
    {
        private readonly IReadRepository<ContractLeasing> readRepository;

        public GetByCustomerContractLeasingHandler(IReadRepository<ContractLeasing> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<ContractLeasingDto> Handle(GetByCustomerContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var leasing = await readRepository.Table
                .Select(c => new ContractLeasingDto
                {
                    Id = c.Id,                   
                    CustomerId = c.CustomerId,
                    Amount = c.Amount,
                    ReturnRate = c.ReturnRate,                   
                    WithdrawRate = c.WithdrawRate,
                    DailyDepositRateCeiling = c.DailyDepositRateCeiling,
                    DailyDepositeRate= c.DailyDepositeRate,
                    Description=c.Description,
                    IsActive = c.IsActive,
                    StartDate=c.StartDate,
                    EndDate=c.EndDate,
                })
                .Where(c=> c.CustomerId == request.CustomerId && c.IsActive ==true)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
