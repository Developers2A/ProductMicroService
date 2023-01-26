using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Queries
{
    public class GetCourierZoneCityMappingByIdQuery : IRequest<CourierZoneCityMappingDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneCityMappingByIdQuery, CourierZoneCityMappingDto>
        {
            private readonly IReadRepository<CourierZoneCityMapping> _courierZoneCityMappingRepository;
            private readonly IMapper _mapper;

            public Handler(
                IReadRepository<CourierZoneCityMapping> courierZoneCityMappingRepository,
                IMapper mapper)
            {
                _courierZoneCityMappingRepository = courierZoneCityMappingRepository;
                _mapper = mapper;
            }

            public async Task<CourierZoneCityMappingDto> Handle(GetCourierZoneCityMappingByIdQuery request, CancellationToken cancellationToken)
            {
                var courierZoneCityMapping = await _courierZoneCityMappingRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return new CourierZoneCityMappingDto()
                {
                    CityId = courierZoneCityMapping.CityId,
                    CourierCode = courierZoneCityMapping.CourierZone.Courier.Code,
                    CourierZoneId = courierZoneCityMapping.CourierZoneId
                };
            }
        }
    }
}