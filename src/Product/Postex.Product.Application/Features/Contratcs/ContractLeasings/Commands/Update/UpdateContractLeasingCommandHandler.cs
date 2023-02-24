using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Update
{
    public class UpdateContractLeasingCommandHandler : IRequestHandler<UpdateContractLeasingCommand, ContractLeasingDto>
    {
        private readonly IWriteRepository<ContractLeasing> _writeRepository;
        private readonly IReadRepository<ContractLeasing> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractLeasingCommandHandler(IWriteRepository<ContractLeasing> writeRepository, IReadRepository<ContractLeasing> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }


        async Task<ContractLeasingDto> IRequestHandler<UpdateContractLeasingCommand, ContractLeasingDto>.Handle(UpdateContractLeasingCommand request, CancellationToken cancellationToken)
        {
            var contractLeasing = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractLeasing == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractLeasing.CustomerId = request.CustomerId;
            contractLeasing.StartDate = request.StartDate;
            contractLeasing.EndDate = request.EndDate;
            contractLeasing.IsActive = request.IsActive;
            contractLeasing.Amount = request.Amount;
            contractLeasing.DailyDepositeRate = request.DailyDepositeRate;
            contractLeasing.DailyDepositRateCeiling = request.DailyDepositRateCeiling;
            contractLeasing.ReturnRate = request.ReturnRate;
            contractLeasing.WithdrawRate = request.WithdrawRate;
            contractLeasing.Description = request.Description;

            await _writeRepository.UpdateAsync(contractLeasing);
            await _writeRepository.SaveChangeAsync(cancellationToken);

            var dto = _mapper.Map<ContractLeasingDto>(contractLeasing);
            return dto;
        }
    }
}
