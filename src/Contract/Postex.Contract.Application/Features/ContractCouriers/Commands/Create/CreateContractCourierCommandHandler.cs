using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Application.Features.ContractCouriers.Command.Create
{
    public class CreateContractCourierCommandHandler : IRequestHandler<CreateContractCourierCommand>
    {
        private readonly IWriteRepository<ContractCourier> _writeRepository;

        public CreateContractCourierCommandHandler(IWriteRepository<ContractCourier> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractCourierCommand request, CancellationToken cancellationToken)
        {
            var contractCourier = new ContractCourier
            {
                ContractInfoId = request.ContractInfoId,
                CourierId=request.CourierId,
                FixedDiscount=request.FixedDiscount,
                PercentDiscount=request.PercentDiscount,
                IsActive =request.IsActive,
                Description=request.Description,

            };
            await _writeRepository.AddAsync(contractCourier);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
