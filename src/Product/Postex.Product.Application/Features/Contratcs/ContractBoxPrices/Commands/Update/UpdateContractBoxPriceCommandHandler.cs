using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Update
{
    public class UpdateContractBoxPriceCommandHandler : IRequestHandler<UpdateContractBoxPriceCommand, ContractBoxPriceDto>
    {
        private readonly IWriteRepository<ContractBoxPrice> _writeRepository;
        private readonly IReadRepository<ContractBoxPrice> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractBoxPriceCommandHandler(IWriteRepository<ContractBoxPrice> writeRepository, IReadRepository<ContractBoxPrice> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractBoxPriceDto> IRequestHandler<UpdateContractBoxPriceCommand, ContractBoxPriceDto>.Handle(UpdateContractBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var contractBoxType = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractBoxType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractBoxType.BoxTypeId = request.BoxTypeId;
            contractBoxType.CityId = request.CityId;
            contractBoxType.ProvinceId = request.ProvinceId;
            contractBoxType.CustomerId = request.CustomerId;
            contractBoxType.SalePrice = request.SalePrice;
            contractBoxType.BuyPrice = request.BuyPrice;
            contractBoxType.Description = request.Description;
            contractBoxType.IsActive = request.IsActive;

            await _writeRepository.UpdateAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync();
            var dto = _mapper.Map<ContractBoxPriceDto>(contractBoxType);
            return dto;
        }
    }
}
