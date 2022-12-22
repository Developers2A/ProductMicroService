using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZones.Queries
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
                        Code = c.Code,
                        CourierId = c.CourierId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierServiceZoneDto;
            }
        }
    }
}