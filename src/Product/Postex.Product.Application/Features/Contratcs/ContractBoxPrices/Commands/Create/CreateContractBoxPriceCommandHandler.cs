using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractBoxPrices.Command.Create
{
    internal class CreateContractBoxPriceCommandHandler : IRequestHandler<CreateContractBoxPriceCommand>
    {
        private readonly IWriteRepository<ContractBoxPrice> _writeRepository;

        public CreateContractBoxPriceCommandHandler(IWriteRepository<ContractBoxPrice> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var contractBoxType = new ContractBoxPrice
            {
                ContractInfoId = request.ContractInfoId,
                BoxTypeId = request.BoxTypeId,
                CityId = request.CityId,
                ProvinceId = request.ProvinceId,
                CustomerId = request.CustomerId,
                SalePrice = request.SalePrice,
                BuyPrice = request.BuyPrice,
                Description = request.Description,
                IsActive = request.IsActive
            };
            await _writeRepository.AddAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
