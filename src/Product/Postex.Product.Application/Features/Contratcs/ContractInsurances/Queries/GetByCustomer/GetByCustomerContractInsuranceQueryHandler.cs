using MediatR;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postex.Product.Domain.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomer
{
    public class GetByCustomerContractInsuranceQueryHandler : IRequestHandler<GetByCustomerContractInsuranceQuery, List<ContractInsuranceDto>>
    {
        private readonly IReadRepository<ContractInsurance> _readRepository;

        public GetByCustomerContractInsuranceQueryHandler(IReadRepository<ContractInsurance> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractInsuranceDto>> Handle(GetByCustomerContractInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insuranceCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
               .Select(c => new ContractInsuranceDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   FromValue = c.FromValue,
                   ToValue = c.ToValue,
                   FixedPercent = c.FixedPercent,
                   FixedValue = c.FixedValue,
                   Description = c.Description,
                   IsActice = c.IsActice,
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);
            if (insuranceCus.Count != 0)
                return insuranceCus;



            var insuranceCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null)
              .Select(c => new ContractInsuranceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  FromValue = c.FromValue,
                  ToValue = c.ToValue,
                  FixedPercent = c.FixedPercent,
                  FixedValue = c.FixedValue,
                  Description = c.Description,
                  IsActice = c.IsActice,
                  LevelPrice = "City"
              })
              .ToListAsync(cancellationToken);
            if (insuranceCity.Count != 0)
                return insuranceCity;

            var insuranceDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == null && c.ContractInfo.CityId == null && c.ContractInfo.ProvinceId == null)
           .Select(c => new ContractInsuranceDto
           {
               Id = c.Id,
               ContractInfoId = c.ContractInfoId,
               FromValue = c.FromValue,
               ToValue = c.ToValue,
               FixedPercent = c.FixedPercent,
               FixedValue = c.FixedValue,
               Description = c.Description,
               IsActice = c.IsActice,
               LevelPrice = "Default"

           })
           .ToListAsync(cancellationToken);

            return insuranceDefualt;

        }
    }
}
