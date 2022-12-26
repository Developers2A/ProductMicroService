using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierZonePrices.Queries
{
    public class GetCourierServiceZonePriceByIdQuery : IRequest<CourierZonePriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierServiceZonePriceByIdQuery, CourierZonePriceDto>
        {
            private readonly IReadRepository<CourierZonePriceDto> _courierServiceZonePriceReadRepository;

            public Handler(IReadRepository<CourierZonePriceDto> courierServiceZonePriceReadRepository)
            {
                _courierServiceZonePriceReadRepository = courierServiceZonePriceReadRepository;
            }

            public async Task<CourierZonePriceDto> Handle(GetCourierServiceZonePriceByIdQuery request, CancellationToken cancellationToken)
            {
                var courierZone = await _courierServiceZonePriceReadRepository.Table
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
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierZone;
            }
        }
    }
}