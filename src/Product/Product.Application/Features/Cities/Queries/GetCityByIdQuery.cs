using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.Cities.Queries
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCityByIdQuery, CityDto>
        {
            private readonly IReadRepository<City> _cityReadRepository;

            public Handler(IReadRepository<City> cityReadRepository)
            {
                _cityReadRepository = cityReadRepository;
            }

            public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
            {
                var city = await _cityReadRepository.TableNoTracking
                    .Select(c => new CityDto
                    {
                        Id = c.Id,
                        StateId = c.StateId,
                        Name = c.Name,
                        Code = c.Code,
                        EnglishName = c.EnglishName
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return city;
            }
        }
    }
}