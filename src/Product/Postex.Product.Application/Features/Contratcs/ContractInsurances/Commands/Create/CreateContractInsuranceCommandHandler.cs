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

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Create
{
    public class CreateContractInsuranceCommandHandler : IRequestHandler<CreateContractInsuranceCommand, ContractInsuranceDto>
    {
        private readonly IWriteRepository<ContractInsurance> _writeRepositort;
        private readonly IMapper _mapper;

        public CreateContractInsuranceCommandHandler(IWriteRepository<ContractInsurance> writeRepositort, IMapper mapper)
        {
            _writeRepositort = writeRepositort;
            _mapper = mapper;
        }


        async Task<ContractInsuranceDto> IRequestHandler<CreateContractInsuranceCommand, ContractInsuranceDto>.Handle(CreateContractInsuranceCommand request, CancellationToken cancellationToken)
        {
            var contractInsurance = _mapper.Map<ContractInsurance>(request);
            await _writeRepositort.AddAsync(contractInsurance);
            await _writeRepositort.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractInsuranceDto>(contractInsurance);
            return dto;
        }
    }
}
