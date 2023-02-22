using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contracts.Commands.CreateContractCommand
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand,ContractInfoDto>
    {
        private readonly IWriteRepository<ContractInfo> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCommandHandler(IWriteRepository<ContractInfo> writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }       
       async Task<ContractInfoDto> IRequestHandler<CreateContractCommand, ContractInfoDto>.Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var contractInfo = _mapper.Map<ContractInfo>(request);
            await _writeRepository.AddAsync(contractInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractInfoDto>(contractInfo);
            return dto;
        }
    }
}
