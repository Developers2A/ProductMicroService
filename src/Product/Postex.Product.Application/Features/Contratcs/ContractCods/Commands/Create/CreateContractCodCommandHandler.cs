using AutoMapper;
using MediatR;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractCods.Command.Create
{
    public class CreateContractCodCommandHandler : IRequestHandler<CreateContractCodCommand>
    {
        private readonly IWriteRepository<ContractCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCodCommandHandler(IWriteRepository<ContractCod> writeRepository,IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateContractCodCommand request, CancellationToken cancellationToken)
        {
            //var contractCod = new ContractCod
            //{
            //    ContractInfoId = request.ContractInfoId,
            //    FromValue = request.FromValue,
            //    ToValue = request.ToValue,
            //    FixedPercent = request.FixedPercent,
            //    FixedValue = request.FixedValue,
            //    Description=request.Description,
            //};
            var contractCod = _mapper.Map<ContractCod>(request);
            await _writeRepository.AddAsync(contractCod);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
