using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZones.Queries
{
    public class GetCourierServiceZoneByIdQuery : IRequest<CourierServiceZoneDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierServiceZoneByIdQuery, CourierServiceZoneDto>
        {
            private readonly IReadRepository<CourierServiceZone> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierServiceZone> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<CourierServiceZoneDto> Handle(GetCourierServiceZoneByIdQuery request, CancellationToken cancellationToken)
            {
                var courierServiceZoneDto = await _courierZoneReadRepository.TableNoTracking
                    .Select(c => new CourierServiceZoneDto
                    {
                        Id = c.Id,
                        StateFromId = c.StateFromId,
                        StateToId = c.StateToId,
                        CityFromId = c.CityFromId,
                        CityToId = c.CityToId,
                        CourierServiceId = c.CourierServiceId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierServiceZoneDto;
            }
        }
    }
}