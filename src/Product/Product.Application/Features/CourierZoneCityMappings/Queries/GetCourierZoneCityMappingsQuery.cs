using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZoneCityMappings.Queries
{
    public class GetCourierZoneCityMappingsQuery : IRequest<List<CourierZoneCityMappingDto>>
    {
        public List<int>? CourierZoneIds { get; set; }
        public List<int>? CityIds { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneCityMappingsQuery, List<CourierZoneCityMappingDto>>
        {
            private readonly IReadRepository<CourierZoneCityMapping> _courierZoneCityMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierZoneCityMapping> courierZoneCityMappingReadRepository, IMapper mapper)
            {
                _courierZoneCityMappingReadRepository = courierZoneCityMappingReadRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierZoneCityMappingDto>> Handle(GetCourierZoneCityMappingsQuery request, CancellationToken cancellationToken)
            {
                var courierZoneCityMappingQuery = _courierZoneCityMappingReadRepository.TableNoTracking;
                if (request.CourierZoneIds != null && request.CourierZoneIds.Any())
                {
                    courierZoneCityMappingQuery = courierZoneCityMappingQuery.Where(x => request.CourierZoneIds.Contains(x.CourierZoneId));
                }
                if (request.CityIds != null && request.CityIds.Any())
                {
                    courierZoneCityMappingQuery = courierZoneCityMappingQuery.Where(x => request.CityIds.Contains(x.CityId));
                }
                var courierZoneCityMappings = await courierZoneCityMappingQuery.Include(x => x.CourierZone).ThenInclude(x => x.Courier)
                    .ToListAsync(cancellationToken);

                return courierZoneCityMappings.Select(x => new CourierZoneCityMappingDto()
                {
                    CityId = x.CityId,
                    CourierCode = x.CourierZone.Courier.Code,
                    CourierZoneId = x.CourierZoneId
                }).ToList();
            }
        }
    }
}