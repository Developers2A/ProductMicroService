using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetById
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
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            return leasing;
        }
    }
}
