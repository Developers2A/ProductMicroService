using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Application.Features.ContractLeasingWarranties.Commands.Create
{
    public class CreateContractLeasingWarrantyCommandHandler : IRequestHandler<CreateContractLeasingWarrantyCommand>
    {
        private readonly IWriteRepository<ContractLeasingWarranty> writeRepository;
        private readonly IMapper mapper;

        public CreateContractLeasingWarrantyCommandHandler(IWriteRepository<ContractLeasingWarranty> writeRepository,IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateContractLeasingWarrantyCommand request, CancellationToken cancellationToken)
        {
            var contractLeasingWaranty = mapper.Map<ContractLeasingWarranty>(request);
            
            await writeRepository.AddAsync(contractLeasingWaranty);
            await writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
