using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomer
{
    public class GetByCustomerContractCourierQueryHandler : IRequestHandler<GetByCustomerContractCourierQuery, List<ContractCourierDto>>
    {
        private readonly IReadRepository<ContractCourier> _readRepository;

        public GetByCustomerContractCourierQueryHandler(IReadRepository<ContractCourier> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractCourierDto>> Handle(GetByCustomerContractCourierQuery request, CancellationToken cancellationToken)
        {
            var courierCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
               .Select(c => new ContractCourierDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   CourierServiceId = c.CourierServiceId,
                   FixedDiscount = c.FixedDiscount,
                   PercentDiscount = c.PercentDiscount,
                   IsActive = c.IsActive,
                   Description = c.Description,
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);


            var courierCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null)
              .Select(c => new ContractCourierDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  CourierServiceId = c.CourierServiceId,
                  FixedDiscount = c.FixedDiscount,
                  PercentDiscount = c.PercentDiscount,
                  IsActive = c.IsActive,
                  Description = c.Description,
                  LevelPrice = "City"
              })
              .ToListAsync(cancellationToken);

            var courierDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0)
           .Select(c => new ContractCourierDto
           {
               Id = c.Id,
               ContractInfoId = c.ContractInfoId,
               CourierServiceId = c.CourierServiceId,
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

                if (courierCus.Where(c => c.CourierServiceId == item.CourierServiceId)
                    .FirstOrDefault() != null)
                {
                    var cus = courierCus.Where(c => c.CourierServiceId == item.CourierServiceId)
                      .FirstOrDefault();
                    courierDefualt[i].FixedDiscount = cus.FixedDiscount;
                    courierDefualt[i].PercentDiscount = cus.PercentDiscount;
                    courierDefualt[i].LevelPrice = "Customer";

                }
                else if (courierCity.Where(c => c.CourierServiceId == item.CourierServiceId)
                    .FirstOrDefault() != null)
                {
                    var cus = courierCity.Where(c => c.CourierServiceId == item.CourierServiceId)
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
