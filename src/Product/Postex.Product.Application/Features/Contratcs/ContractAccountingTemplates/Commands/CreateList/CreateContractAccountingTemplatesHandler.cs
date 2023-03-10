using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.CreateList
{
    public class CreateContractAccountingTemplatesHandler : IRequestHandler<CreateContractAccountingTemplatesCommand>
    {
        private readonly IWriteRepository<ContractAccountingTemplate> _writeRepository;

        public CreateContractAccountingTemplatesHandler(IWriteRepository<ContractAccountingTemplate> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractAccountingTemplatesCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.ContractAccountingTemplates)
            {
                var contractAccountingTemplate = new ContractAccountingTemplate
                {
                    ContractInfoId = item.ContractInfoId,
                    CustomerId = item.CustomerId,
                    ContractDetailType = item.ContractDetailType,
                    ContractDetailId = item.ContractDetailId,
                    PercentValue = item.PercentValue,
                    FixedValue = item.FixedValue,
                    Description = item.Description,
                    IsActive = true
                };
                await _writeRepository.AddAsync(contractAccountingTemplate);
            };
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }



    }
}

