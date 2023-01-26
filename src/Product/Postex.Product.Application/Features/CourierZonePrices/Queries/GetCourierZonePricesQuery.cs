using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Queries
{
    public class GetCourierZonePricesQuery : IRequest<List<CourierZonePriceDto>>
    {
        public class Handler : IRequestHandler<GetCourierZonePricesQuery, List<CourierZonePriceDto>>
        {
            private readonly IReadRepository<CourierZonePrice> _courierZonePriceReadRepository;

            public Handler(IReadRepository<CourierZonePrice> courierZonePriceReadRepository)
            {
                _courierZonePriceReadRepository = courierZonePriceReadRepository;
            }

            public async Task<List<CourierZonePriceDto>> Handle(GetCourierZonePricesQuery request, CancellationToken cancellationToken)
            {
                var courierZonePrices = await _courierZonePriceReadRepository.TableNoTracking
                    .Select(c => new CourierZonePriceDto
                    {
                        Id = c.Id,
                        CourierServiceId = c.CourierServiceId,
                        FromCourierZoneId = c.FromCourierZoneId,
                        ToCourierZoneId = c.ToCourierZoneId,
                        BuyPrice = c.BuyPrice,
                        SellPrice = c.SellPrice,
                        Weight = c.Weight
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierZonePrices;
            }
        }
    }
}