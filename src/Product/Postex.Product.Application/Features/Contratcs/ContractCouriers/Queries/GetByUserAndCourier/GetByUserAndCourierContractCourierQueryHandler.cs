using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByUserAndCourier
{
    public class GetByUserAndCourierContractCourierQueryHandler : IRequestHandler<GetByUserAndCourierContractCourierQuery, CourierServicePriceDto>
    {
        private readonly IReadRepository<ContractCourier> _readRepository;

        public GetByUserAndCourierContractCourierQueryHandler(IReadRepository<ContractCourier> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<CourierServicePriceDto> Handle(GetByUserAndCourierContractCourierQuery request, CancellationToken cancellationToken)
        {

            var courierDefualt = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierServiceId == request.CourierServiceId)
               .Select(c => new CourierServicePriceDto
               {
                   ContractId = c.ContractInfoId,
                   ContractCourierId = c.Id,
                   DefaultFixedDiscount = c.FixedDiscount,
                   DefaultPercentDiscount = c.PercentDiscount,
                   ContractLevel = "Default"
               })
                 .FirstOrDefaultAsync(cancellationToken);


            var courierCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == request.UserId && c.CourierServiceId == request.CourierServiceId)
               .Select(c => new CourierServicePriceDto
               {
                   ContractId = c.ContractInfoId,
                   ContractCourierId = c.Id,
                   ContractFixedDiscount = c.FixedDiscount,
                   ContractPercentDiscount = c.PercentDiscount,
               })
               .FirstOrDefaultAsync(cancellationToken);

            if (courierCus != null)
            {
                courierDefualt.ContractId = courierCus.ContractId;
                courierDefualt.ContractCourierId = courierCus.ContractCourierId;
                courierDefualt.ContractFixedDiscount = courierCus.ContractFixedDiscount;
                courierDefualt.ContractPercentDiscount = courierCus.ContractPercentDiscount;
                courierDefualt.ContractLevel = "Customer";

                return courierDefualt;
            }

            var courierCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierServiceId == request.CourierServiceId)
              .Select(c => new CourierServicePriceDto
              {
                  ContractId = c.ContractInfoId,
                  ContractCourierId = c.Id,
                  ContractFixedDiscount = c.FixedDiscount,
                  ContractPercentDiscount = c.PercentDiscount,
              })
               .FirstOrDefaultAsync(cancellationToken);

            if (courierCus != null)
            {
                courierDefualt.ContractId = courierCity.ContractId;
                courierDefualt.ContractCourierId = courierCity.ContractCourierId;
                courierDefualt.ContractFixedDiscount = courierCity.ContractFixedDiscount;
                courierDefualt.ContractPercentDiscount = courierCity.ContractPercentDiscount;
                courierDefualt.ContractLevel = "City";

                return courierDefualt;
            }

            var courierProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == 0 && c.ContractInfo.UserId == null && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.CourierServiceId == request.CourierServiceId)
             .Select(c => new CourierServicePriceDto
             {
                 ContractId = c.ContractInfoId,
                 ContractCourierId = c.Id,
                 ContractFixedDiscount = c.FixedDiscount,
                 ContractPercentDiscount = c.PercentDiscount,
             })
               .FirstOrDefaultAsync(cancellationToken);
            if (courierProvince != null)
            {
                courierDefualt.ContractId = courierProvince.ContractId;
                courierDefualt.ContractCourierId = courierProvince.ContractCourierId;
                courierDefualt.ContractFixedDiscount = courierProvince.ContractFixedDiscount;
                courierDefualt.ContractPercentDiscount = courierProvince.ContractPercentDiscount;
                courierDefualt.ContractLevel = "Province";

                return courierDefualt;
            }


            return courierDefualt;

        }
    }
}
