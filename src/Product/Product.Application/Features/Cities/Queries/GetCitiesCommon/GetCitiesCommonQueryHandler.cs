using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.Cities.Queries.GetCitiesCommon
{
    public class GetCitiesCommonQueryHandler : IRequestHandler<GetCitiesCommonQuery, List<CityCommonDto>>
    {
        private readonly IReadRepository<City> _cityReadRepository;

        public GetCitiesCommonQueryHandler(IReadRepository<City> cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<List<CityCommonDto>> Handle(GetCitiesCommonQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityReadRepository.TableNoTracking.Include(x => x.State)
                .Where(x => x.State.Code == request.StateCode)
                .Select(c => new CityCommonDto
                {
                    Code = c.Code,
                    Name = c.Name,
                    StateCode = c.State.Code
                })
                .ToListAsync(cancellationToken);

            return cities;
        }
    }
}
