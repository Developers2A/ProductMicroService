using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Create
{
    public class CreateContractLeasingCommandHandler : IRequestHandler<CreateContractLeasingCommand, ContractLeasingDto>
    {
        private readonly IWriteRepository<ContractLeasing> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractLeasingCommandHandler(IWriteRepository<ContractLeasing> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractLeasingDto> IRequestHandler<CreateContractLeasingCommand, ContractLeasingDto>.Handle(CreateContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var contractLeasing = _mapper.Map<ContractLeasing>(request);
            await _writeRepository.AddAsync(contractLeasing);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractLeasingDto>(contractLeasing);
            return dto;
        }
    }
}
