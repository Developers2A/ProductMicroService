using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractAccountingTemplates.Queries.GetContractById
{

    public class GetByContractIdContractAccountingTemplateHandler : IRequestHandler<GetByContractIdContractAccountingTemplate, ContractAccountingTemplate>
    {
        private readonly IReadRepository<ContractAccountingTemplate> _readRepository;
        private readonly IMapper _mapper;

        public GetByContractIdContractAccountingTemplateHandler(IReadRepository<ContractAccountingTemplate> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }

        public async Task<ContractAccountingTemplate> Handle(GetByContractIdContractAccountingTemplate request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
                .Select(c=> new ContractAccountingTemplate
                {
                    Id=c.Id,
                    ContractInfoId=c.ContractInfoId,
                    ContractDetailType=c.ContractDetailType,
                    ContractDetailId=c.ContractDetailId,
                    PercentValue =c.PercentValue,
                    FixedValue=c.FixedValue,
                    Description=c.Description,                                                       
                })
                .Where(c=> c.ContractInfoId == request.ContractInfoId)
                .FirstOrDefaultAsync(cancellationToken);
                
            return info;
        }
    }

   
}
