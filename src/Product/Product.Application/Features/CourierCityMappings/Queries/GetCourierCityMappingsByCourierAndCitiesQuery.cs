using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCityMappings.Queries
{
    public class GetCourierCityMappingsByCourierAndCitiesQuery : IRequest<List<CourierCityMappingDto>>
    {
        public int CourierCode { get; set; }
        public List<int> CityCodes { get; set; }

        public class Handler : IRequestHandler<GetCourierCityMappingsByCourierAndCitiesQuery, List<CourierCityMappingDto>>
        {
            private readonly IReadRepository<CourierCityMapping> _courierCityMappingRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierCityMapping> courierCityMappingRepository, IMapper mapper)
            {
                _courierCityMappingRepository = courierCityMappingRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierCityMappingDto>> Handle(GetCourierCityMappingsByCourierAndCitiesQuery request, CancellationToken cancellationToken)
            {
                var courierCityMappingQuery = _courierCityMappingRepository.TableNoTracking
                    .Include(x => x.Courier).Where(x => request.CityCodes.Contains(x.Code));
                if ((int)request.CourierCode > 0)
                {
                    courierCityMappingQuery = courierCityMappingQuery.Where(x => x.Courier.Code == (CourierCode)request.CourierCode);
                }

                var courierCities = await courierCityMappingQuery.Include(x => x.Courier).ToListAsync();
                return _mapper.Map<List<CourierCityMappingDto>>(courierCities);
            }
        }
    }
}