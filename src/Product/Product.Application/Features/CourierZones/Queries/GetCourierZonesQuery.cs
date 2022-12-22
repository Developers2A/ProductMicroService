using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Enums;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZones.Queries
{
    public class GetCourierZonesQuery : IRequest<List<CourierZoneDto>>
    {
        public List<int>? Ids { get; set; }
        public CityTypeCode? Code { get; set; }

        public class Handler : IRequestHandler<GetCourierZonesQuery, List<CourierZoneDto>>
        {
            private readonly IReadRepository<CourierZone> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierZone> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<List<CourierZoneDto>> Handle(GetCourierZonesQuery request, CancellationToken cancellationToken)
            {
                var courierZoneQuery = _courierZoneReadRepository.TableNoTracking;
                if (request.Code.HasValue && request.Code > 0)
                {
                    courierZoneQuery.Where(x => x.Code == (CityTypeCode)request.Code);
                }
                if (request.Ids != null && request.Ids.Any())
                {
                    courierZoneQuery.Where(x => request.Ids.Contains(x.Id));
                }
                var courierZoneDtos = await courierZoneQuery.Select(c => new CourierZoneDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    CourierId = c.CourierId,
                }).OrderByDescending(c => c.Id).ToListAsync(cancellationToken);

                return courierZoneDtos;
            }
        }
    }
}