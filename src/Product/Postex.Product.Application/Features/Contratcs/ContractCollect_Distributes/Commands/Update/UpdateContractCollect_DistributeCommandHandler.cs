using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractCollect_Distributes.Command.Update
{
    public class UpdateContractCollect_DistributeCommandHandler : IRequestHandler<UpdateContractCollect_DistributeCommand>
    {
        private readonly IWriteRepository<ContractCollectionDistribution> _writeRepository;
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;

        public UpdateContractCollect_DistributeCommandHandler(IWriteRepository<ContractCollectionDistribution> writeRepository, IReadRepository<ContractCollectionDistribution> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<Unit> Handle(UpdateContractCollect_DistributeCommand request, CancellationToken cancellationToken)
        {
            ContractCollectionDistribution contractCollect_Distribute = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractCollect_Distribute == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");


            contractCollect_Distribute.BoxTypeId = request.BoxTypeId;
            contractCollect_Distribute.CityId = request.CityId;
            contractCollect_Distribute.ProvinceId = request.ProvinceId;
            contractCollect_Distribute.SalePrice = request.SalePrice;
            contractCollect_Distribute.BuyPrice = request.BuyPrice;
            contractCollect_Distribute.Description = request.Description;
            contractCollect_Distribute.IsActice = request.IsActice;

            await _writeRepository.UpdateAsync(contractCollect_Distribute);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
