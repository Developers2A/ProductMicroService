﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCityMappings.Queries
{
    public class GetCourierCityMappingsQuery : IRequest<List<CourierCityMappingDto>>
    {
        public class Handler : IRequestHandler<GetCourierCityMappingsQuery, List<CourierCityMappingDto>>
        {
            private readonly IReadRepository<CourierCityMapping> _courierCityMappingRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierCityMapping> courierCityMappingRepository, IMapper mapper)
            {
                _courierCityMappingRepository = courierCityMappingRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierCityMappingDto>> Handle(GetCourierCityMappingsQuery request, CancellationToken cancellationToken)
            {
                var courierCities = await _courierCityMappingRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return _mapper.Map<List<CourierCityMappingDto>>(courierCities);
            }
        }
    }
}