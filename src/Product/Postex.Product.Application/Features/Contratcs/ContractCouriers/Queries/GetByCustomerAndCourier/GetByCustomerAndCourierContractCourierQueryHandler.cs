using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomerAndCourier
{
    public class GetByCustomerAndCourierContractCourierQueryHandler : IRequestHandler<GetByCustomerAndCourierContractCourierQuery, List<ContractCourierDto>>
    {
        private readonly IReadRepository<ContractCourier> _readRepository;

        public GetByCustomerAndCourierContractCourierQueryHandler(IReadRepository<ContractCourier> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractCourierDto>> Handle(GetByCustomerAndCourierContractCourierQuery request, CancellationToken cancellationToken)
        {
            var courierCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == request.CustomerId && c.CourierId == request.CourierId)
               .Select(c => new ContractCourierDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   CourierId = c.CourierId,
                   FixedDiscount = c.FixedDiscount,
                   PercentDiscount = c.PercentDiscount,
                   IsActive = c.IsActive,
                   Description = c.Description,
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);

            if (courierCus.Count > 0)
                return courierCus;

            var courierCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierId == request.CourierId)
              .Select(c => new ContractCourierDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  CourierId = c.CourierId,
                  FixedDiscount = c.FixedDiscount,
                  PercentDiscount = c.PercentDiscount,
                  IsActive = c.IsActive,
                  Description = c.Description,
                  LevelPrice = "City"
              })
              .ToListAsync(cancellationToken);

            if (courierCity.Count > 0)
                return courierCus;

            var courierProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierId == request.CourierId)
             .Select(c => new ContractCourierDto
             {
                 Id = c.Id,
                 ContractInfoId = c.ContractInfoId,
                 CourierId = c.CourierId,
                 FixedDiscount = c.FixedDiscount,
                 PercentDiscount = c.PercentDiscount,
                 IsActive = c.IsActive,
                 Description = c.Description,
                 LevelPrice = "Province"
             })
             .ToListAsync(cancellationToken);
            if (courierProvince.Count > 0)
                return courierProvince;

            var courierDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierId == request.CourierId)
           .Select(c => new ContractCourierDto
           {
               Id = c.Id,
               ContractInfoId = c.ContractInfoId,
               CourierId = c.CourierId,
               FixedDiscount = c.FixedDiscount,
               PercentDiscount = c.PercentDiscount,
               IsActive = c.IsActive,
               Description = c.Description,
               LevelPrice = "Default"

           })
           .ToListAsync(cancellationToken);


            for (int i = 0; i < courierDefualt.Count; i++)
            {
                var item = courierDefualt[i];

                if (courierCus.Where(c => c.CourierId == item.CourierId)
                    .FirstOrDefault() != null)
                {
                    var cus = courierCus.Where(c => c.CourierId == item.CourierId)
                      .FirstOrDefault();
                    courierDefualt[i].FixedDiscount = cus.FixedDiscount;
                    courierDefualt[i].PercentDiscount = cus.PercentDiscount;
                    courierDefualt[i].LevelPrice = "Customer";

                }
                else if (courierCity.Where(c => c.CourierId == item.CourierId)
                    .FirstOrDefault() != null)
                {
                    var cus = courierCity.Where(c => c.CourierId == item.CourierId)
                      .FirstOrDefault();
                    courierDefualt[i].FixedDiscount = cus.FixedDiscount;
                    courierDefualt[i].PercentDiscount = cus.PercentDiscount;
                    courierDefualt[i].LevelPrice = "City";

                }
            }

            return courierDefualt;

        }
    }
}
