﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Couriers;
using Product.Domain.Enums;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetMinParcelCityQuery : PaginationParameters, IRequest<ParcelCityDto>
    {
        public CityTypeCode CityType { get; set; }

        public class Handler : IRequestHandler<GetMinParcelCityQuery, ParcelCityDto>
        {
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierCityTypePrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<ParcelCityDto> Handle(GetMinParcelCityQuery request, CancellationToken cancellationToken)
            {
                var parcelCity = await _parcelCityRepository.TableNoTracking.Include(x => x.Courier).Where(x => x.CityType == request.CityType).FirstAsync(cancellationToken);

                var parcelcityDto = new ParcelCityDto()
                {
                    Id = parcelCity.Id,
                    SellPrice = parcelCity.SellPrice,
                    BuyPrice = parcelCity.BuyPrice,
                    CityType = parcelCity.CityType,
                    Volume = parcelCity.Volume,
                    CreatedOn = parcelCity.CreatedOn
                };

                return parcelcityDto;
            }
        }
    }
}