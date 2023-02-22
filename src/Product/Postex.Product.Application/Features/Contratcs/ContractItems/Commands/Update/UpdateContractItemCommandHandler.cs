using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractItems.Commands.UpdateContractItem
{
    public class UpdateContractItemCommandHandler : IRequestHandler<UpdateContractItemCommand, ContractItemDto>
    {
        private readonly IWriteRepository<ContractItem> _writeRepository;
        private readonly IReadRepository<ContractItem> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractItemCommandHandler(IWriteRepository<ContractItem> writeRepository, IReadRepository<ContractItem> readRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
         

       async Task<ContractItemDto> IRequestHandler<UpdateContractItemCommand, ContractItemDto>.Handle(UpdateContractItemCommand request, CancellationToken cancellationToken)
        {
            ContractItem contractitem = await _readRepository.GetByIdAsync(request.
                Id, cancellationToken);

            if (contractitem == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractitem.CourierId = request.CourierId;
            contractitem.ContractItemType = request.ContractItemType;
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
