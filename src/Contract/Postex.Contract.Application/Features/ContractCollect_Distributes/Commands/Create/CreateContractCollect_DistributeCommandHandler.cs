using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Application.Features.ContractCollect_Distributes.Command.Create
{
    internal class CreateContractCollect_DistributeCommandHandler : IRequestHandler<CreateContractCollect_DistributeCommand>
    {
        private readonly IWriteRepository<ContractCollect_Distribute> _writeRepository;

        public CreateContractCollect_DistributeCommandHandler(IWriteRepository<ContractCollect_Distribute> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractCollect_DistributeCommand request, CancellationToken cancellationToken)
        {
            var contractCollect_Distribute = new ContractCollect_Distribute
            {
                ContractInfoId = request.ContractInfoId,
                BoxTypeId = request.BoxTypeId,
                CityId = request.CityId,
                ProvinceId = request.ProvinceId,
                SalePrice = request.SalePrice,
                BuyPrice = request.BuyPrice,
                Description = request.Description,
                IsActice=request.IsActice,
            };
            await _writeRepository.AddAsync(contractCollect_Distribute);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
