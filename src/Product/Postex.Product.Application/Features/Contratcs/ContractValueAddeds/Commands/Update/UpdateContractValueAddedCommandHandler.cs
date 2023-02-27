using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Update
{
    public class UpdateContractValueAddedCommandHandler : IRequestHandler<UpdateContractValueAddedCommand, ContractValueAddedDto>
    {
        private readonly IWriteRepository<ContractValueAdded> _writeRepository;
        private readonly IReadRepository<ContractValueAdded> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractValueAddedCommandHandler(IWriteRepository<ContractValueAdded> writeRepository, IReadRepository<ContractValueAdded> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractValueAddedDto> IRequestHandler<UpdateContractValueAddedCommand, ContractValueAddedDto>.Handle(UpdateContractValueAddedCommand request, CancellationToken cancellationToken)
        {
            ContractValueAdded contractitem = await _readRepository.GetByIdAsync(request.
                Id, cancellationToken);

            if (contractitem == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractitem.CourierId = request.CourierId;
            contractitem.ValueAddedTypeId = request.ValueAddedTypeId;
            contractitem.ProvinceId = request.ProvinceId;
            contractitem.CityId = request.CityId;
            contractitem.IsActive = request.IsActive;
            contractitem.SalePrice = request.SalePrice;
            contractitem.BuyPrice = request.BuyPrice;
            contractitem.Description = request.Description;

            await _writeRepository.UpdateAsync(contractitem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);

            var dto = _mapper.Map<ContractValueAddedDto>(contractitem);
            return dto;
        }
    }
}
