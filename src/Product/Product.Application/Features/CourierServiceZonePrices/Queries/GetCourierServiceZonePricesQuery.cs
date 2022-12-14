using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Queries
{
    public class GetCourierServiceZonePricesQuery : IRequest<List<CourierServiceZonePriceDto>>
    {
        public class Handler : IRequestHandler<GetCourierServiceZonePricesQuery, List<CourierServiceZonePriceDto>>
        {
            private readonly IReadRepository<CourierServiceZonePrice> _courierServiceZonePriceReadRepository;

            public Handler(IReadRepository<CourierServiceZonePrice> courierServiceZonePriceReadRepository)
            {
                _courierServiceZonePriceReadRepository = courierServiceZonePriceReadRepository;
            }

            public async Task<List<CourierServiceZonePriceDto>> Handle(GetCourierServiceZonePricesQuery request, CancellationToken cancellationToken)
            {
                var courierZonePrices = await _courierServiceZonePriceReadRepository.TableNoTracking
                    .Select(c => new CourierServiceZonePriceDto
                    {
                        Id = c.Id,
                        CreatedOn = c.CreatedOn
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierZonePrices;
            }
        }
    }
}