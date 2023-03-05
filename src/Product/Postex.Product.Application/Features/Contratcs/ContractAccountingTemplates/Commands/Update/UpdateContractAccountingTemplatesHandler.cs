using MediatR;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.Update
{
    public class UpdateContractAccountingTemplatesHandler : IRequestHandler<UpdateContractAccountingTemplatesCommand>
    {
        private readonly IWriteRepository<ContractAccountingTemplate> _writeRepository;
        private readonly IReadRepository<ContractAccountingTemplate> _readRepository;

        public UpdateContractAccountingTemplatesHandler(IWriteRepository<ContractAccountingTemplate> writeRepository, IReadRepository<ContractAccountingTemplate> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<Unit> Handle(UpdateContractAccountingTemplatesCommand request, CancellationToken cancellationToken)
        {
            var contractIntoId = request.ContractAccountingTemplates.FirstOrDefault().ContractInfoId;
            var ContractDetailType = request.ContractAccountingTemplates.FirstOrDefault().ContractDetailType;
            var ContractDetailId = request.ContractAccountingTemplates.FirstOrDefault().ContractDetailId;

            var items = _readRepository.Table.Where(c => c.ContractInfoId == contractIntoId && c.ContractDetailId == ContractDetailId && c.ContractDetailType == ContractDetailType && c.IsActive == false).ToList();
            if (items != null)
            {
                foreach (var item in items)
                {
                    item.IsActive = false;
                }
                await _writeRepository.UpdateRangeAsync(items);
            }

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
                await _writeRepository.AddAsync(contractAccountingTemplate, cancellationToken);
            };
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
