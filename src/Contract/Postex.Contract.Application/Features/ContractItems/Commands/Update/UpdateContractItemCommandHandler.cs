using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItems.Commands.Update
{
    public class UpdateContractItemCommandHandler : IRequestHandler<UpdateContractItemCommand>
    {
        private readonly IWriteRepository<ContractItem> _writeRepository;
        private readonly IReadRepository<ContractItem> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractItemCommandHandler(IWriteRepository<ContractItem> writeRepository, IReadRepository<ContractItem> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateContractItemCommand request, CancellationToken cancellationToken)
        {
            ContractItem contractitem = await _readRepository.GetByIdAsync(request.
                Id, cancellationToken);

            if (contractitem == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractitem.CourierId = request.CourierId;
            contractitem.ContractItemTypeId = request.ContractItemTypeId;
            contractitem.ProvinceId = request.ProvinceId;
            contractitem.CityId = request.CityId;
            contractitem.IsActive = request.IsActive;
            contractitem.SalePrice = request.SalePrice;
            contractitem.BuyPrice = request.BuyPrice;
            contractitem.Description = request.Description;

            await _writeRepository.UpdateAsync(contractitem, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
