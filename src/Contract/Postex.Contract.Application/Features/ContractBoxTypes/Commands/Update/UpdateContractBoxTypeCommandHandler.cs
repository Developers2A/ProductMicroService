using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractBoxTypes.Command.Update
{
    public class UpdateContractBoxTypeCommandHandler : IRequestHandler<UpdateContractBoxTypeCommand>
    {
        private readonly IWriteRepository<ContractBoxType> _writeRepository;
        private readonly IReadRepository<ContractBoxType> _readRepository;

        public UpdateContractBoxTypeCommandHandler(IWriteRepository<ContractBoxType> writeRepository, IReadRepository<ContractBoxType> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<Unit> Handle(UpdateContractBoxTypeCommand request, CancellationToken cancellationToken)
        {
            ContractBoxType contractBoxType = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractBoxType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");


            contractBoxType.BoxTypeId = request.BoxTypeId;
            contractBoxType.CityId = request.CityId;
            contractBoxType.ProvinceId = request.ProvinceId;
            contractBoxType.SalePrice = request.SalePrice;
            contractBoxType.BuyPrice = request.BuyPrice;
            contractBoxType.Description= request.Description;

            await _writeRepository.UpdateAsync(contractBoxType);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
