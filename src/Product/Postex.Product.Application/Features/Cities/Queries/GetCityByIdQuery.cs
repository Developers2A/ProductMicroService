using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Cities.Queries
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
                        ProvinceId = c.ProvinceId,
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