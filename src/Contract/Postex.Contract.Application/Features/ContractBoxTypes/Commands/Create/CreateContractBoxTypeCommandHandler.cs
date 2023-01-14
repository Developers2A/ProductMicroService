using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractBoxTypes.Command.Create
{
    internal class CreateContractBoxTypeCommandHandler : IRequestHandler<CreateContractBoxTypeCommand>
    {
        private readonly IWriteRepository<ContractBoxType> _writeRepository;

        public CreateContractBoxTypeCommandHandler(IWriteRepository<ContractBoxType> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractBoxTypeCommand request, CancellationToken cancellationToken)
        {
            var contractBoxType = new ContractBoxType
            {
                ContractInfoId = request.ContractInfoId,
                BoxTypeId = request.BoxTypeId,
                CityId = request.CityId,
                ProvinceId = request.ProvinceId,
                SalePrice = request.SalePrice,
                BuyPrice = request.BuyPrice,
                Description = request.Description,
            };
            await _writeRepository.AddAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
