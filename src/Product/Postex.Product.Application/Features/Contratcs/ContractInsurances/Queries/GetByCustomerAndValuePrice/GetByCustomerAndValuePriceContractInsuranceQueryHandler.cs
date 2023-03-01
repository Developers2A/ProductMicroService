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

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomerAndValuePrice
{
    public class GetByCustomerAndValuePriceContractInsuranceQueryHandler : IRequestHandler<GetByCustomerAndValuePriceContractInsuranceQuery, InsurancePriceDto>
    {
        private readonly IReadRepository<ContractInsurance> _readRepository;

        public GetByCustomerAndValuePriceContractInsuranceQueryHandler(IReadRepository<ContractInsurance> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<InsurancePriceDto> Handle(GetByCustomerAndValuePriceContractInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insurance = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
              .Select(c => new InsurancePriceDto
              {
                  ContractId = c.ContractInfoId,
                  ContractInsuranceId = c.Id,
                  ValuePrice = request.ValuePrice,
                  DefaultFixedValue = c.FixedValue,
                  DefaultFixedPercent = c.FixedPercent,
                  ContractLevel = "Default"

              })
              .FirstOrDefaultAsync(cancellationToken);

            var insuranceCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == request.CustomerId && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
                .Select(c => new InsurancePriceDto
                {
                    ContractId = c.ContractInfoId,
                    ContractInsuranceId = c.Id,                   
                    ContractFixedValue = c.FixedValue,
                    ContractFixedPercent = c.FixedPercent,                    
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (insuranceCus != null)
            {
                insurance.ContractId = insuranceCus.ContractId;
                insurance.ContractInsuranceId = insuranceCus.ContractInsuranceId;
                insurance.ContractFixedValue = insuranceCus.ContractFixedValue;
                insurance.ContractFixedPercent = insuranceCus.ContractFixedPercent;
                insurance.ContractLevel = "Customer";
                return insurance;
            }


            var insuranceCity = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
            .Select(c => new InsurancePriceDto
            {
                ContractId = c.ContractInfoId,
                ContractInsuranceId = c.Id,
                ContractFixedValue = c.FixedValue,
                ContractFixedPercent = c.FixedPercent,
            })
             .FirstOrDefaultAsync(cancellationToken);

            if (insuranceCity != null)
            {
                insurance.ContractId = insuranceCity.ContractId;
                insurance.ContractInsuranceId = insuranceCity.ContractInsuranceId;
                insurance.ContractFixedValue = insuranceCity.ContractFixedValue;
                insurance.ContractFixedPercent = insuranceCity.ContractFixedPercent;
                insurance.ContractLevel = "City";
                return insurance;
            }

            var insuranceProvince = await _readRepository.Table
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.FromValue >= request.ValuePrice && c.ToValue <= request.ValuePrice)
            .Select(c => new InsurancePriceDto
            {
                ContractId = c.ContractInfoId,
                ContractInsuranceId = c.Id,
                ContractFixedValue = c.FixedValue,
                ContractFixedPercent = c.FixedPercent,
            })
            .FirstOrDefaultAsync(cancellationToken);

            if (insuranceProvince != null)
            {
                insurance.ContractId = insuranceProvince.ContractId;
                insurance.ContractInsuranceId = insuranceProvince.ContractInsuranceId;
                insurance.ContractFixedValue = insuranceProvince.ContractFixedValue;
                insurance.ContractFixedPercent = insuranceProvince.ContractFixedPercent;
                insurance.ContractLevel = "Province";
                return insurance;
            }


            return insurance;
        }
    }
}
