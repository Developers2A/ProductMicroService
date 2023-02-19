using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractBoxPrices.Command.Update
{
    public class UpdateContractBoxPriceCommandHandler : IRequestHandler<UpdateContractBoxPriceCommand>
    {
        private readonly IWriteRepository<ContractBoxPrice> _writeRepository;
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public UpdateContractBoxPriceCommandHandler(IWriteRepository<ContractBoxPrice> writeRepository, IReadRepository<ContractBoxPrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<Unit> Handle(UpdateContractBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var contractBoxType = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractBoxType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");


            contractBoxType.BoxTypeId = request.BoxTypeId;
            contractBoxType.CityId = request.CityId;
            contractBoxType.ProvinceId = request.ProvinceId;
            contractBoxType.CustomerId= request.CustomerId;
            contractBoxType.SalePrice = request.SalePrice;
            contractBoxType.BuyPrice = request.BuyPrice;
            contractBoxType.Description= request.Description;
            contractBoxType.IsActive = request.IsActive;

            await _writeRepository.UpdateAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
