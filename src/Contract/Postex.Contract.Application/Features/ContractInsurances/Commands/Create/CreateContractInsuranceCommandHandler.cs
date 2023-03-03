using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractInsurances.Commands.Create
{
    public class CreateContractInsuranceCommandHandler : IRequestHandler<CreateContractInsuranceCommand>
    {
        private readonly IWriteRepository<ContractInsurance> _writeRepositort;

        public CreateContractInsuranceCommandHandler(IWriteRepository<ContractInsurance> writeRepositort)
        {
            _writeRepositort = writeRepositort;
        }
        public async Task<Unit> Handle(CreateContractInsuranceCommand request, CancellationToken cancellationToken)
        {
            var contractInsurance = new ContractInsurance()
            {
                ContractInfoId = request.ContractInfoId,
                FromValue = request.FromValue,
                ToValue = request.ToValue,
                FixedPercent = request.FixedPercent,
                FixedValue = request.FixedValue,
                Description = request.Description,
                IsActice = request.IsActice
            };
            await _writeRepositort.AddAsync(contractInsurance);
            await _writeRepositort.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
