using MediatR;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractAccountingTemplates.Commands.Create
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
                ContractInfoId = request.ContractInfoId,
                CustomerId = request.CustomerId,
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
