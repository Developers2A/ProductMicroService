using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Update
{
    public class UpdateContractCollect_DistributeCommandHandler : IRequestHandler<UpdateContractCollect_DistributeCommand, ContractCollectionDistributionDto>
    {
        private readonly IWriteRepository<ContractCollectionDistribution> _writeRepository;
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractCollect_DistributeCommandHandler(IWriteRepository<ContractCollectionDistribution> writeRepository, IReadRepository<ContractCollectionDistribution> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractCollectionDistributionDto> IRequestHandler<UpdateContractCollect_DistributeCommand, ContractCollectionDistributionDto>.Handle(UpdateContractCollect_DistributeCommand request, CancellationToken cancellationToken)
        {
            ContractCollectionDistribution contractCollect_Distribute = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractCollect_Distribute == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");


            contractCollect_Distribute.BoxTypeId = request.BoxTypeId;
            contractCollect_Distribute.CourierServiceId = request.CourierServiceId;            
            contractCollect_Distribute.CityId = request.CityId;
            contractCollect_Distribute.ProvinceId = request.ProvinceId;
            contractCollect_Distribute.SalePrice = request.SalePrice;
            contractCollect_Distribute.BuyPrice = request.BuyPrice;
            contractCollect_Distribute.Description = request.Description;
            contractCollect_Distribute.IsActice = request.IsActice;

            await _writeRepository.UpdateAsync(contractCollect_Distribute);
            await _writeRepository.SaveChangeAsync();

            var dto = _mapper.Map<ContractCollectionDistributionDto>(contractCollect_Distribute);
            return dto;
        }
    }
}
