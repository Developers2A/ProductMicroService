using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractCouriers.Command.Create
{
    public class CreateContractCourierCommandHandler : IRequestHandler<CreateContractCourierCommand, ContractCourierDto>
    {
        private readonly IWriteRepository<ContractCourier> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCourierCommandHandler(IWriteRepository<ContractCourier> writeRepository,IMapper mapper)
        {
            _writeRepository = writeRepository;
            this._mapper = mapper;
        }        

     async   Task<ContractCourierDto> IRequestHandler<CreateContractCourierCommand, ContractCourierDto>.Handle(CreateContractCourierCommand request, CancellationToken cancellationToken)
        {
            var contractCourier = _mapper.Map<ContractCourier>(request);
            await _writeRepository.AddAsync(contractCourier);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto=_mapper.Map<ContractCourierDto>(contractCourier);
            return dto;
        }
    }
}
