using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplateHandler : IRequestHandler<CreateContractAccountingTemplateCommand>
    {
        private readonly IWriteRepository<ContractAccountingTemplate> _writeRepository;

        public CreateContractAccountingTemplateHandler(IWriteRepository<ContractAccountingTemplate> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<Unit> Handle(CreateContractAccountingTemplateCommand request, CancellationToken cancellationToken)
        {
            var item = new ContractAccountingTemplate
            {
                ContractInfoId = request.ContractInfoId,
                UserId = request.UserId,
                ContractDetailType = request.ContractDetailType,
                ContractDetailId = request.ContractDetailId,
                PercentValue = request.PercentValue,
                FixedValue = request.FixedValue,
                Description = request.Description,
                IsActive = true
            };
            await _writeRepository.AddAsync(item);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
