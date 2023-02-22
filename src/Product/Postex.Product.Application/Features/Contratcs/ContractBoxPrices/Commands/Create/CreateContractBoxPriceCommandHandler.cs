using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractBoxPrices.Command.Create
{
    internal class CreateContractBoxPriceCommandHandler : IRequestHandler<CreateContractBoxPriceCommand, ContractBoxPriceDto>
    {
        private readonly IWriteRepository<ContractBoxPrice> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractBoxPriceCommandHandler(IWriteRepository<ContractBoxPrice> writeRepository,IMapper mapper)
        {
            _writeRepository = writeRepository;
            this._mapper = mapper;
        }
         

      async  Task<ContractBoxPriceDto> IRequestHandler<CreateContractBoxPriceCommand, ContractBoxPriceDto>.Handle(CreateContractBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var contractBoxType = _mapper.Map<ContractBoxPrice>(request);
            await _writeRepository.AddAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractBoxPriceDto>(contractBoxType);
            return dto;
        }
    }
}
