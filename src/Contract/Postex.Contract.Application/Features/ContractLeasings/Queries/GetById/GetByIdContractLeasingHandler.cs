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

namespace Postex.Contract.Application.Features.ContractLeasings.Queries.GetById
{
    public class GetByIdContractLeasingHandler : IRequestHandler<GetByIdContractLeasingCommand, ContractLeasingDto>
    {
        private readonly IReadRepository<ContractLeasing> readRepository;

        public GetByIdContractLeasingHandler(IReadRepository<ContractLeasing> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<ContractLeasingDto> Handle(GetByIdContractLeasingCommand request, CancellationToken cancellationToken)
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
                .Where(c=> c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
