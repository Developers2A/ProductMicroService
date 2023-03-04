using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractLeasings.Commands.Create
{
    public class CreateContractLeasingCommandHandler : IRequestHandler<CreateContractLeasingCommand>
    {
        private readonly IWriteRepository<ContractLeasing> writeRepository;

        public CreateContractLeasingCommandHandler(IWriteRepository<ContractLeasing> writeRepository)
        {
            this.writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var contractLeasing = new ContractLeasing()
            {
                CustomerId = request.CustomerId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive,
                Amount = request.Amount,
                DailyDepositeRate = request.DailyDepositeRate,
                DailyDepositRateCeiling = request.DailyDepositRateCeiling,
                ReturnRate = request.ReturnRate,
                WithdrawRate = request.WithdrawRate,
                Description=request.Description,
            };
            await writeRepository.AddAsync(contractLeasing);
            await writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
