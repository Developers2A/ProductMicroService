using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByContractId
{
    public class GetByContractIdContractCourierQueryHandler : IRequestHandler<GetByContractIdContractCourierQuery, List<ContractCourierDto>>
    {
        private readonly IReadRepository<ContractCourier> _readRepository;

        public GetByContractIdContractCourierQueryHandler(IReadRepository<ContractCourier> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractCourierDto>> Handle(GetByContractIdContractCourierQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table
                .Select(c => new ContractCourierDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    CourierServiceId = c.CourierServiceId,
                    FixedDiscount = c.FixedDiscount,
                    PercentDiscount = c.PercentDiscount,
                    IsActive = c.IsActive,
                    Description = c.Description,
                })
                .ToListAsync(cancellationToken);
            return cod;
        }
    }

}
