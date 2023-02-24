using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Update
{
    public class UpdateContractLeasingWarrantyCommandHandler : IRequestHandler<UpdateContractLeasingWarrantyCommand, ContractLeasingWarrantyDto>
    {
        private readonly IWriteRepository<ContractLeasingWarranty> _writeRepository;
        private readonly IReadRepository<ContractLeasingWarranty> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractLeasingWarrantyCommandHandler(IWriteRepository<ContractLeasingWarranty> writeRepository, IReadRepository<ContractLeasingWarranty> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractLeasingWarrantyDto> IRequestHandler<UpdateContractLeasingWarrantyCommand, ContractLeasingWarrantyDto>.Handle(UpdateContractLeasingWarrantyCommand request, CancellationToken cancellationToken)
        {
            ContractLeasingWarranty contractLeasingWaranty = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractLeasingWaranty == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractLeasingWaranty = _mapper.Map<ContractLeasingWarranty>(request);
            await _writeRepository.UpdateAsync(contractLeasingWaranty);
            await _writeRepository.SaveChangeAsync();
            var dto = _mapper.Map<ContractLeasingWarrantyDto>(contractLeasingWaranty);
            return dto;
        }
    }
}
