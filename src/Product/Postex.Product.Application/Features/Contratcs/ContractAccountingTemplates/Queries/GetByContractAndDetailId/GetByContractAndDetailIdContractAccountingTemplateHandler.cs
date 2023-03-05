using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Queries.GetByContractAndDetailId
{
    public class GetByContractAndDetailIdContractAccountingTemplateHandler : IRequestHandler<GetByContractAndDetailIdContractAccountingTemplate, List<ContractAccountingTemplate>>
    {
        private readonly IReadRepository<ContractAccountingTemplate> _readRepository;
        private readonly IMapper _mapper;

        public GetByContractAndDetailIdContractAccountingTemplateHandler(IReadRepository<ContractAccountingTemplate> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<List<ContractAccountingTemplate>> Handle(GetByContractAndDetailIdContractAccountingTemplate request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
                .Select(c => new ContractAccountingTemplate
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    ContractDetailType = c.ContractDetailType,
                    ContractDetailId = c.ContractDetailId,
                    PercentValue = c.PercentValue,
                    FixedValue = c.FixedValue,
                    Description = c.Description,
                })
                .Where(c => c.ContractInfoId == request.ContractInfoId && c.ContractDetailId == request.ContractDeatilId && c.ContractDetailType == request.ContractDetailType && c.IsActive == true)
                .ToListAsync(cancellationToken);

            return info;
        }
    }
}
