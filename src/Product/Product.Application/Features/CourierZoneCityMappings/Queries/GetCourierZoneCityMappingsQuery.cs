using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierZoneCityMappingsQuery : IRequest<List<CourierZoneCityMappingDto>>
    {
        public List<int>? CourierZoneIds { get; set; }
        public List<int>? CityIds { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneCityMappingsQuery, List<CourierZoneCityMappingDto>>
        {
            private readonly IReadRepository<CourierZoneCityMapping> _courierStatusMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierZoneCityMapping> courierStatusMappingReadRepository, IMapper mapper)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierZoneCityMappingDto>> Handle(GetCourierZoneCityMappingsQuery request, CancellationToken cancellationToken)
            {
                var courierZoneCityMappingQuery = _courierStatusMappingReadRepository.TableNoTracking;
                if (request.CourierZoneIds != null && request.CourierZoneIds.Any())
                {
                    courierZoneCityMappingQuery = courierZoneCityMappingQuery.Where(x => request.CourierZoneIds.Contains(x.CourierZoneId));
                }
                if (request.CityIds != null && request.CityIds.Any())
                {
                    courierZoneCityMappingQuery = courierZoneCityMappingQuery.Where(x => request.CityIds.Contains(x.CityId));
                }
                var courierStatusMappings = await courierZoneCityMappingQuery
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierZoneCityMappingDto>>(courierStatusMappings);
            }
        }
    }
}