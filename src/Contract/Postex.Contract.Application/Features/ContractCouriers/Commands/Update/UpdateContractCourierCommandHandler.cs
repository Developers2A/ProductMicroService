using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCouriers.Commands.Update
{
    public class UpdateContractCourierCommandHandler : IRequestHandler<UpdateContractCourierCommand>
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
        public async Task<Unit> Handle(UpdateContractCourierCommand request, CancellationToken cancellationToken)
        {
            ContractCourier contractCourier = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractCourier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractCourier.CourierId = request.CourierId;
            contractCourier.FixedDiscount = request.FixedDiscount;
            contractCourier.PercentDiscount = request.PercentDiscount;
            contractCourier.IsActive = request.IsActive;
            contractCourier.Description = request.Description;

            await _writeRepository.UpdateAsync(contractCourier);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
