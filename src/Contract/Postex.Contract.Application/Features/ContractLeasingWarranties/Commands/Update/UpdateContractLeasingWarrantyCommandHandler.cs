using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Application.Features.ContractLeasingWarranties.Commands.Update
{
    public class UpdateContractLeasingWarrantyCommandHandler : IRequestHandler<UpdateContractLeasingWarrantyCommand>
    {
        private readonly IWriteRepository<ContractLeasingWarranty> writeRepository;
        private readonly IReadRepository<ContractLeasingWarranty> readRepository;
        private readonly IMapper mapper;

        public UpdateContractLeasingWarrantyCommandHandler(IWriteRepository<ContractLeasingWarranty> writeRepository, IReadRepository<ContractLeasingWarranty> readRepository, IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateContractLeasingWarrantyCommand request, CancellationToken cancellationToken)
        {


            ContractLeasingWarranty warranty = await readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (warranty == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            var updateWarranty = mapper.Map(request, warranty);
            await writeRepository.UpdateAsync(updateWarranty);
            await writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
