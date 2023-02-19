using AutoMapper;
using MediatR;
using Postex.Product.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.UpdateContractItemType
{
    internal class UpdateContractItemTypeCommandHandler : IRequestHandler<UpdateContractItemTypeCommand>
    {
        private readonly IWriteRepository<ContractItemType> _writeRepository;
        private readonly IReadRepository<ContractItemType> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractItemTypeCommandHandler(IWriteRepository<ContractItemType> writeRepository,IReadRepository<ContractItemType> readRepository,IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._readRepository = readRepository;
            this._mapper = mapper;
           
        }
        public async Task<Unit> Handle(UpdateContractItemTypeCommand request, CancellationToken cancellationToken)
        {
            ContractItemType contractItemType = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractItemType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            //  var updateContractItemType = _mapper.Map(request, contractItemType);
            contractItemType.ContractTypeName = request.ContractTypeName;
            contractItemType.ContractTypeCode = request.ContractTypeCode;

            await _writeRepository.UpdateAsync(contractItemType);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
