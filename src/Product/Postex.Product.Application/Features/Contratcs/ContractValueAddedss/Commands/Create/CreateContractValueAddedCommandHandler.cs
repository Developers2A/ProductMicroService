using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Create
{
    public class CreateContractValueAddedCommandHandler : IRequestHandler<CreateContractContractValueAddedCommand, ContractItemDto>
    {
        private readonly IWriteRepository<ContractValueAdded> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractValueAddedCommandHandler(IWriteRepository<ContractValueAdded> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractItemDto> IRequestHandler<CreateContractContractValueAddedCommand, ContractItemDto>.Handle(CreateContractContractValueAddedCommand request, CancellationToken cancellationToken)
        {
            var contractItem = _mapper.Map<ContractValueAdded>(request);
            await _writeRepository.AddAsync(contractItem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractItemDto>(contractItem);
            return dto;
        }
    }
}
