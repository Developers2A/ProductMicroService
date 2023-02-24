using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Create
{
    public class CreateContractLeasingWarrantyCommandHandler : IRequestHandler<CreateContractLeasingWarrantyCommand, ContractLeasingWarrantyDto>
    {
        private readonly IWriteRepository<ContractLeasingWarranty> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractLeasingWarrantyCommandHandler(IWriteRepository<ContractLeasingWarranty> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractLeasingWarrantyDto> IRequestHandler<CreateContractLeasingWarrantyCommand, ContractLeasingWarrantyDto>.Handle(CreateContractLeasingWarrantyCommand request, CancellationToken cancellationToken)
        {
            var contractLeasingWaranty = _mapper.Map<ContractLeasingWarranty>(request);

            await _writeRepository.AddAsync(contractLeasingWaranty);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractLeasingWarrantyDto>(contractLeasingWaranty);
            return dto;
        }
    }
}
