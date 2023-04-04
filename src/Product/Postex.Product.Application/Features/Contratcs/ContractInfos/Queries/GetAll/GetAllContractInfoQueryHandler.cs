using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetAll
{
    public class GetAllContractInfoQueryHandler : IRequestHandler<GetAllContractInfoQuery, List<ContractInfoDto>>
    {
        private readonly IReadRepository<ContractInfo> readRepository;

        public GetAllContractInfoQueryHandler(IReadRepository<ContractInfo> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<List<ContractInfoDto>> Handle(GetAllContractInfoQuery request, CancellationToken cancellationToken)
        {
            var items = await readRepository.Table.Select
                (c => new ContractInfoDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    UserId = c.UserId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    IsActive = c.IsActive,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                }
                ).ToListAsync(cancellationToken);
            return items;
        }
    }
}
