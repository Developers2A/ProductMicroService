using AutoMapper;
using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractItems.Commands.CreateContractItem
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
                ContractItemType = request.ContractItemType,
                ProvinceId = request.ProvinceId,
                CityId = request.CityId,
                IsActive = request.IsActive,
                SalePrice = request.SalePrice,
                BuyPrice = request.BuyPrice,
                Description = request.Description,
            };
            await _writeRepository.AddAsync(contractItem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
