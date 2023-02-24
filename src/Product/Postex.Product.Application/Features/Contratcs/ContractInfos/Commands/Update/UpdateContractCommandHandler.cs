using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Exceptions;
using Postex.Product.Domain.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Update
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, ContractInfoDto>
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


        async Task<ContractInfoDto> IRequestHandler<UpdateContractCommand, ContractInfoDto>.Handle(UpdateContractCommand request, CancellationToken cancellationToken)
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
            var dto = _mapper.Map<ContractInfoDto>(contractInfo);
            return dto;
        }
    }
}
