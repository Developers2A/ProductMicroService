using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAs.Queries
{
    public class GetCourierZoneSLAByIdQuery : IRequest<CourierZoneSLADto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneSLAByIdQuery, CourierZoneSLADto>
        {
            private readonly IReadRepository<CourierZoneSLA> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierZoneSLA> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<CourierZoneSLADto> Handle(GetCourierZoneSLAByIdQuery request, CancellationToken cancellationToken)
            {
                var courierZoneSLA = await _courierZoneReadRepository.TableNoTracking
                    .Select(c => new CourierZoneSLADto
                    {
                        Id = c.Id,
                        StateFromId = c.StateFromId,
                        StateToId = c.StateToId,
                        CityFromId = c.CityFromId,
                        CityToId = c.CityToId,
                        SLAId = c.SLAId,
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierZoneSLA;
            }
        }
    }
}