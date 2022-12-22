using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Queries
{
    public class GetCourierZonePricesQuery : IRequest<List<CourierZonePriceDto>>
    {
        public class Handler : IRequestHandler<GetCourierZonePricesQuery, List<CourierZonePriceDto>>
        {
            private readonly IReadRepository<CourierZonePrice> _courierServiceZonePriceReadRepository;

            public Handler(IReadRepository<CourierZonePrice> courierServiceZonePriceReadRepository)
            {
                _courierServiceZonePriceReadRepository = courierServiceZonePriceReadRepository;
            }

            public async Task<List<CourierZonePriceDto>> Handle(GetCourierZonePricesQuery request, CancellationToken cancellationToken)
            {
                var courierZonePrices = await _courierServiceZonePriceReadRepository.TableNoTracking
                    .Select(c => new CourierZonePriceDto
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