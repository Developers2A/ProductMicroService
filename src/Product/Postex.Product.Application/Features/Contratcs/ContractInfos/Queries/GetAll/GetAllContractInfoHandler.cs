using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetAll
{
    public class GetAllContractInfoHandler : IRequestHandler<GetAllContractInfoCommand, List<ContractInfoDto>>
    {
        private readonly IReadRepository<ContractInfo> readRepository;

        public GetAllContractInfoHandler(IReadRepository<ContractInfo> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<List<ContractInfoDto>> Handle(GetAllContractInfoCommand request, CancellationToken cancellationToken)
        {
            var items = await readRepository.Table.Select
                (c => new ContractInfoDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CustomerId = c.CustomerId,
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
