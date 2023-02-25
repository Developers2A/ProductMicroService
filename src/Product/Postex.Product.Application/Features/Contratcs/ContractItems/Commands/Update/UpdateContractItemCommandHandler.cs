using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Update
{
    public class UpdateContractItemCommandHandler : IRequestHandler<UpdateContractItemCommand, ContractItemDto>
    {
        private readonly IWriteRepository<ContractItem> _writeRepository;
        private readonly IReadRepository<ContractItem> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractItemCommandHandler(IWriteRepository<ContractItem> writeRepository, IReadRepository<ContractItem> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractItemDto> IRequestHandler<UpdateContractItemCommand, ContractItemDto>.Handle(UpdateContractItemCommand request, CancellationToken cancellationToken)
        {
            ContractItem contractitem = await _readRepository.GetByIdAsync(request.
                Id, cancellationToken);

            if (contractitem == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractitem.CourierId = request.CourierId;
            contractitem.ContractItemTypeId = request.ContractItemTypeId;
            contractitem.ProvinceId = request.ProvinceId;
            contractitem.CityId = request.CityId;
            contractitem.IsActive = request.IsActive;
            contractitem.SalePrice = request.SalePrice;
            contractitem.BuyPrice = request.BuyPrice;
            contractitem.Description = request.Description;

            await _writeRepository.UpdateAsync(contractitem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);

            var dto = _mapper.Map<ContractItemDto>(contractitem);
            return dto;
        }
    }
}
