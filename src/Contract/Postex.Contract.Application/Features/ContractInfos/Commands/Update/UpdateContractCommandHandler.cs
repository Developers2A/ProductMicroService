using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;

namespace Postex.Contract.Application.Features.ContractInfos.Commands.Update
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand>
    {
        private readonly IWriteRepository<ContractInfo> _writeRepository;
        private readonly IReadRepository<ContractInfo> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractCommandHandler(IWriteRepository<ContractInfo> writeRepository, IReadRepository<ContractInfo> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {

            ContractInfo contractInfo = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractInfo == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractInfo.ContractNo = request.ContractNo;
            contractInfo.Title = request.Title;
            contractInfo.Description = request.Description;
            contractInfo.StartDate = request.StartDate;
            contractInfo.EndDate = request.EndDate;
            contractInfo.RegisterDate = request.RegisterDate;
            contractInfo.IsActive = request.IsActive;

            contractInfo.CustomerId = request.CustomerId;

            await _writeRepository.UpdateAsync(contractInfo);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }

    }
}
