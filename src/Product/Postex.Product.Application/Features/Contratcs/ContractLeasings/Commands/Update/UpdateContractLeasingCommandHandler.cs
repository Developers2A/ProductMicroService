using MediatR;
using Postex.Product.Application.Features.ContractLeasings.Command.Create;
using Postex.Product.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractLeasings.Commands.Update
{
    public class UpdateContractLeasingCommandHandler : IRequestHandler<UpdateContractLeasingCommand>
    {
        private readonly IWriteRepository<ContractLeasing> writeRepository;
        private readonly IReadRepository<ContractLeasing> readRepository;

        public UpdateContractLeasingCommandHandler(IWriteRepository<ContractLeasing> writeRepository,IReadRepository<ContractLeasing> readRepository)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
        }
        public async Task<Unit> Handle(UpdateContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var contractLeasing = await readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractLeasing == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractLeasing.CustomerId = request.CustomerId;
            contractLeasing.StartDate= request.StartDate;
            contractLeasing.EndDate= request.EndDate;
            contractLeasing.IsActive = request.IsActive;
            contractLeasing.Amount = request.Amount;
            contractLeasing.DailyDepositeRate = request.DailyDepositeRate;
            contractLeasing.DailyDepositRateCeiling = request.DailyDepositRateCeiling;
            contractLeasing.ReturnRate = request.ReturnRate;
            contractLeasing.WithdrawRate = request.WithdrawRate;
            contractLeasing.Description= request.Description;
      
            await writeRepository.UpdateAsync(contractLeasing);
            await writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
