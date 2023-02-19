using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractInfos.Queries.GetAll
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
