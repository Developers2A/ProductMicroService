using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.Cities.Queries
{
    public class GetCitiesQuery : IRequest<List<CityDto>>
    {
        public class Handler : IRequestHandler<GetCitiesQuery, List<CityDto>>
        {
            private readonly IReadRepository<City> _cityReadRepository;

            public Handler(IReadRepository<City> cityReadRepository)
            {
                _cityReadRepository = cityReadRepository;
            }

            public async Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var cities = await _cityReadRepository.TableNoTracking
                    .Select(c => new CityDto
                    {
                        Id = c.Id,
                        StateId = c.StateId,
                        Name = c.Name,
                        EnglishName = c.EnglishName,
                        Code = c.Code
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return cities;
            }
        }
    }
}