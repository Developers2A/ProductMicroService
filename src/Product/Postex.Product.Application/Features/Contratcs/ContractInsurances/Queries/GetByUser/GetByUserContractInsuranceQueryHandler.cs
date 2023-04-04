using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUser
{
    public class GetByUserContractInsuranceQueryHandler : IRequestHandler<GetByUserContractInsuranceQuery, List<ContractInsuranceDto>>
    {
        private readonly IReadRepository<ContractInsurance> _readRepository;

        public GetByUserContractInsuranceQueryHandler(IReadRepository<ContractInsurance> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractInsuranceDto>> Handle(GetByUserContractInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insuranceCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.UserId == request.UserId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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

            var insuranceProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.UserId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                 LevelPrice = "Province"
             })
             .ToListAsync(cancellationToken);
            if (insuranceProvince.Count != 0)
                return insuranceProvince;

            var insuranceDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
