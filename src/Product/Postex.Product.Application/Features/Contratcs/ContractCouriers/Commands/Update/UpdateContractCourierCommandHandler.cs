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

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Update
{
    public class UpdateContractCourierCommandHandler : IRequestHandler<UpdateContractCourierCommand, ContractCourierDto>
    {
        private readonly IWriteRepository<ContractCourier> _writeRepository;
        private readonly IReadRepository<ContractCourier> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractCourierCommandHandler(IWriteRepository<ContractCourier> writeRepository, IReadRepository<ContractCourier> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractCourierDto> IRequestHandler<UpdateContractCourierCommand, ContractCourierDto>.Handle(UpdateContractCourierCommand request, CancellationToken cancellationToken)
        {
            ContractCourier contractCourier = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractCourier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractCourier.CourierServiceId = request.CourierServiceId;
            contractCourier.FixedDiscount = request.FixedDiscount;
            contractCourier.PercentDiscount = request.PercentDiscount;
            contractCourier.IsActive = request.IsActive;
            contractCourier.Description = request.Description;

            await _writeRepository.UpdateAsync(contractCourier);
            await _writeRepository.SaveChangeAsync();

            var dto = _mapper.Map<ContractCourierDto>(contractCourier);
            return dto;
        }
    }
}
