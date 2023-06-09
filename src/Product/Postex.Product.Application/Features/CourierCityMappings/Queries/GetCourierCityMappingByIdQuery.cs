﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCityMappings.Queries
{
    public class GetCourierCityMappingByIdQuery : IRequest<CourierCityMappingDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierCityMappingByIdQuery, CourierCityMappingDto>
        {
            private readonly IReadRepository<CourierCityMapping> _courierCityMappingRepository;
            private readonly IMapper _mapper;

            public Handler(
                IReadRepository<CourierCityMapping> courierCityMappingRepository,
                IMapper mapper)
            {
                _courierCityMappingRepository = courierCityMappingRepository;
                _mapper = mapper;
            }

            public async Task<CourierCityMappingDto> Handle(GetCourierCityMappingByIdQuery request, CancellationToken cancellationToken)
            {
                var courierCities = await _courierCityMappingRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierCityMappingDto>(courierCities);
            }
        }
    }
}