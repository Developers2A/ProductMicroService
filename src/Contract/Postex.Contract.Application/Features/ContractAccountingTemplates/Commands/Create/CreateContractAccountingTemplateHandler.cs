using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplateHandler : IRequestHandler<CreateContractAccountingTemplateCommand>
    {
        private readonly IWriteRepository<ContractAccountingTemplate> _writeRepository;

        public CreateContractAccountingTemplateHandler(IWriteRepository<ContractAccountingTemplate> writeRepository)
        {
            this._writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractAccountingTemplateCommand request, CancellationToken cancellationToken)
        {
            var item = new ContractAccountingTemplate
            {
                AccountId = request.AccountId,
                ContractDetailType = request.ContractDetailType,
                ContractDetailId = request.ContractDetailId,
                PercentValue = request.PercentValue,
                FixedValue = request.FixedValue,
                Description = request.Description,
            };
            await _writeRepository.AddAsync(item);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
