using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Create
{
    public class CreateContractItemCommandHandler : IRequestHandler<CreateContractItemCommand, ContractItemDto>
    {
        private readonly IWriteRepository<ContractItem> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractItemCommandHandler(IWriteRepository<ContractItem> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractItemDto> IRequestHandler<CreateContractItemCommand, ContractItemDto>.Handle(CreateContractItemCommand request, CancellationToken cancellationToken)
        {
            var contractItem = _mapper.Map<ContractItem>(request);
            await _writeRepository.AddAsync(contractItem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractItemDto>(contractItem);
            return dto;
        }
    }
}
