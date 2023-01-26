using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZones.Queries
{
    public class GetCourierZoneByIdQuery : IRequest<CourierZoneDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneByIdQuery, CourierZoneDto>
        {
            private readonly IReadRepository<CourierZone> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierZone> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<CourierZoneDto> Handle(GetCourierZoneByIdQuery request, CancellationToken cancellationToken)
            {
                var courierServiceZoneDto = await _courierZoneReadRepository.TableNoTracking
                    .Select(c => new CourierZoneDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CityType = c.CityType,
                        CourierId = c.CourierId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierServiceZoneDto;
            }
        }
    }
}