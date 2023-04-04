using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetByUser
{
    public class GetByUserContractLeasingHandler : IRequestHandler<GetByUserContractLeasingCommand, ContractLeasingDto>
    {
        private readonly IReadRepository<ContractLeasing> readRepository;

        public GetByUserContractLeasingHandler(IReadRepository<ContractLeasing> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<ContractLeasingDto> Handle(GetByUserContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var leasing = await readRepository.Table
                .Select(c => new ContractLeasingDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Amount = c.Amount,
                    ReturnRate = c.ReturnRate,
                    WithdrawRate = c.WithdrawRate,
                    DailyDepositRateCeiling = c.DailyDepositRateCeiling,
                    DailyDepositeRate = c.DailyDepositeRate,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                })
                .Where(c => c.UserId == request.UserId && c.IsActive == true)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
