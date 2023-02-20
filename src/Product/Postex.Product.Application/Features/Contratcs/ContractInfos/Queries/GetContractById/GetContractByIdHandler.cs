using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contracts.Queries.GetContractById
{

    public class GetContractByIdHandler : IRequestHandler<GetContractById, ContractInfoDto>
    {
        private readonly IReadRepository<ContractInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetContractByIdHandler(IReadRepository<ContractInfo> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }

        public async Task<ContractInfoDto> Handle(GetContractById request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
                .Select(c=> new ContractInfoDto
                {
                    Id=c.Id,
                    ContractNo=c.ContractNo,
                    Title=c.Title,
                    Description=c.Description,
                    StartDate=c.StartDate,
                    EndDate=c.EndDate,
                    RegisterDate=c.RegisterDate,
                    CustomerId=c.CustomerId  ,                 
                })
                .Where(c=> c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
                
            return info;
        }
    }

   
}
