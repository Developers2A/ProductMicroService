﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Cities.Queries.GetCitiesCommon
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
            var cities = await _cityReadRepository.TableNoTracking.Include(x => x.Province)
                .Where(x => x.Province.Code == request.ProvinceCode)
                .Select(c => new CityCommonDto
                {
                    Code = c.Code,
                    Name = c.Name,
                    ProvinceCode = c.Province.Code
                })
                .ToListAsync(cancellationToken);

            return cities;
        }
    }
}
