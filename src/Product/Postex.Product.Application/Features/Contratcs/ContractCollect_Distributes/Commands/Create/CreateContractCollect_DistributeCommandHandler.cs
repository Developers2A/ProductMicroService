﻿using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractCollect_Distributes.Command.Create
{
    internal class CreateContractCollect_DistributeCommandHandler : IRequestHandler<CreateContractCollect_DistributeCommand>
    {
        private readonly IWriteRepository<ContractCollectionDistribution> _writeRepository;

        public CreateContractCollect_DistributeCommandHandler(IWriteRepository<ContractCollectionDistribution> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractCollect_DistributeCommand request, CancellationToken cancellationToken)
        {
            var contractCollect_Distribute = new ContractCollectionDistribution
            {
                ContractInfoId = request.ContractInfoId,
                BoxTypeId = request.BoxTypeId,
                CityId = request.CityId,
                ProvinceId = request.ProvinceId,
                SalePrice = request.SalePrice,
                BuyPrice = request.BuyPrice,
                Description = request.Description,
                IsActice = request.IsActice,
            };
            await _writeRepository.AddAsync(contractCollect_Distribute);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
