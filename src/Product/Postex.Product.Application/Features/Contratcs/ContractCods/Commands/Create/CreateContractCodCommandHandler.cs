using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Commands.Create
{
    public class CreateContractCodCommandHandler : IRequestHandler<CreateContractCodCommand, ContractCodDto>
    {
        private readonly IWriteRepository<ContractCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCodCommandHandler(IWriteRepository<ContractCod> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractCodDto> IRequestHandler<CreateContractCodCommand, ContractCodDto>.Handle(CreateContractCodCommand request, CancellationToken cancellationToken)
        {
            var contractCod = _mapper.Map<ContractCod>(request);
            await _writeRepository.AddAsync(contractCod);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractCodDto>(contractCod);
            return dto;
        }
    }
}
