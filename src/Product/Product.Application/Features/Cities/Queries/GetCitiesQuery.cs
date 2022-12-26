using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.Cities.Queries
{
    public class GetCitiesQuery : IRequest<List<CityDto>>
    {
        public List<int>? CityCodes { get; set; }
        public class Handler : IRequestHandler<GetCitiesQuery, List<CityDto>>
        {
            private readonly IReadRepository<City> _cityReadRepository;

            public Handler(IReadRepository<City> cityReadRepository)
            {
                _cityReadRepository = cityReadRepository;
            }

            public async Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var cityQuery = _cityReadRepository.TableNoTracking;
                if (request.CityCodes != null && request.CityCodes.Any())
                {
                    cityQuery = cityQuery.Where(x => request.CityCodes.Contains(x.Code));
                }
                var cities = await cityQuery
                    .Select(c => new CityDto
                    {
                        Id = c.Id,
                        StateId = c.StateId,
                        Name = c.Name,
                        EnglishName = c.EnglishName,
                        Code = c.Code
                    })
                    .ToListAsync(cancellationToken);

                return cities;
            }
        }
    }
}