using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Application.Features.Contracts.Commands.CreateContractCommand
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand>
    {
        private readonly IWriteRepository<ContractInfo> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCommandHandler(IWriteRepository<ContractInfo> writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var contractInfo = new ContractInfo
            {
                ContractNo = request.ContractNo,
                Title=request.Title,
                Description=request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                RegisterDate = request.RegisterDate,
                IsActive = request.IsActive,

                CustomerId = request.CustomerId,
                CityId=request.CityId,
                ProvinceId=request.ProvinceId,
            };
            await _writeRepository.AddAsync(contractInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
