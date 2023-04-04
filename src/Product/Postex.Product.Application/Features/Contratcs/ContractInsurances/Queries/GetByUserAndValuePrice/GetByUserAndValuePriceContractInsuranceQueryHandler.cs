using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUserAndValuePrice
{
    public class GetByUserAndValuePriceContractInsuranceQueryHandler : IRequestHandler<GetByUserAndValuePriceContractInsuranceQuery, InsurancePriceDto>
    {
        private readonly IReadRepository<ContractInsurance> _readRepository;

        public GetByUserAndValuePriceContractInsuranceQueryHandler(IReadRepository<ContractInsurance> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<InsurancePriceDto> Handle(GetByUserAndValuePriceContractInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insurance = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.FromValue <= request.ValuePrice && c.ToValue >= request.ValuePrice)
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
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == request.UserId && c.FromValue <= request.ValuePrice && c.ToValue >= request.ValuePrice)
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
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null && c.FromValue <= request.ValuePrice && c.ToValue >= request.ValuePrice)
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
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.UserId == null && c.FromValue <= request.ValuePrice && c.ToValue >= request.ValuePrice)
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
