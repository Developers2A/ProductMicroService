using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Features.ContractItems.Commands.CreateContractItem
{
    public class CreateContractItemCommandHandler : IRequestHandler<CreateContractItemCommand>
    {
        private readonly IWriteRepository<ContractItem> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractItemCommandHandler(IWriteRepository<ContractItem> writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(CreateContractItemCommand request, CancellationToken cancellationToken)
        {

            var contractItem = new ContractItem
            {
                ContractInfoId = request.ContractInfoId,
                CourierId = request.CourierId,
                ContractItemTypeId = request.ContractItemTypeId,
                ProvinceId = request.ProvinceId,
                CityId = request.CityId,
                IsActive = request.IsActive,
                SalePrice = request.SalePrice,
                BuyPrice= request.BuyPrice,
                Description= request.Description,
            };
            await _writeRepository.AddAsync(contractItem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
