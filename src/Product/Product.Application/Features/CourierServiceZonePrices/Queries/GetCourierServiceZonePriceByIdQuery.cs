using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Queries
{
    public class GetCourierServiceZonePriceByIdQuery : IRequest<CourierServiceZonePriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierServiceZonePriceByIdQuery, CourierServiceZonePriceDto>
        {
            private readonly IReadRepository<CourierServiceZonePriceDto> _courierServiceZonePriceReadRepository;

            public Handler(IReadRepository<CourierServiceZonePriceDto> courierServiceZonePriceReadRepository)
            {
                _courierServiceZonePriceReadRepository = courierServiceZonePriceReadRepository;
            }

            public async Task<CourierServiceZonePriceDto> Handle(GetCourierServiceZonePriceByIdQuery request, CancellationToken cancellationToken)
            {
                var courierZone = await _courierServiceZonePriceReadRepository.Table
                    .Select(c => new CourierServiceZonePriceDto
                    {
                        Id = c.Id,
                        CreatedOn = c.CreatedOn
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierZone;
            }
        }
    }
}