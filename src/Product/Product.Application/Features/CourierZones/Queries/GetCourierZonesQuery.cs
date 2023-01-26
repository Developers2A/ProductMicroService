using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZones.Queries
{
    public class GetCourierZonesQuery : IRequest<List<CourierZoneDto>>
    {
        public List<int>? Ids { get; set; }
        public CityTypeCode? CityTypeCode { get; set; }

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
                if (request.CityTypeCode.HasValue && request.CityTypeCode > 0)
                {
                    courierZoneQuery.Where(x => x.CityType == (CityTypeCode)request.CityTypeCode);
                }
                if (request.Ids != null && request.Ids.Any())
                {
                    courierZoneQuery.Where(x => request.Ids.Contains(x.Id));
                }
                var courierZoneDtos = await courierZoneQuery.Select(c => new CourierZoneDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityType = c.CityType,
                    CourierId = c.CourierId,
                    EntryPrice = c.EntryPrice
                }).OrderByDescending(c => c.Id).ToListAsync(cancellationToken);

                return courierZoneDtos;
            }
        }
    }
}