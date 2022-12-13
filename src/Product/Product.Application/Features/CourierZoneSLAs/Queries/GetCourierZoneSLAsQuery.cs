using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAs.Queries
{
    public class GetCourierZoneSLAsQuery : IRequest<List<CourierZoneSLADto>>
    {
        public class Handler : IRequestHandler<GetCourierZoneSLAsQuery, List<CourierZoneSLADto>>
        {
            private readonly IReadRepository<CourierZoneSLA> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierZoneSLA> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<List<CourierZoneSLADto>> Handle(GetCourierZoneSLAsQuery request, CancellationToken cancellationToken)
            {
                var courierZoneSLADtos = await _courierZoneReadRepository.TableNoTracking
                    .Select(c => new CourierZoneSLADto
                    {
                        Id = c.Id,
                        StateFromId = c.StateFromId,
                        StateToId = c.StateToId,
                        CityFromId = c.CityFromId,
                        CityToId = c.CityToId,
                        CourierId = c.CourierId,
                        SLAId = c.SLAId
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierZoneSLADtos;
            }
        }
    }
}