using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractCods.Command.Create
{
    public class CreateContractCodCommandHandler : IRequestHandler<CreateContractCodCommand>
    {
        private readonly IWriteRepository<ContractCod> _writeRepository;

        public CreateContractCodCommandHandler(IWriteRepository<ContractCod> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractCodCommand request, CancellationToken cancellationToken)
        {
            var contractCod = new ContractCod
            {
                ContractInfoId = request.ContractInfoId,
                FromValue = request.FromValue,
                ToValue = request.ToValue,
                FixedPercent = request.FixedPercent,
                FixedValue = request.FixedValue,
                Description=request.Description,
            };
            await _writeRepository.AddAsync(contractCod);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
