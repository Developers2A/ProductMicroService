﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;
using ProductService.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingsQuery : IRequest<List<CourierStatusMappingDto>>
    {
        public class Handler : IRequestHandler<GetCourierStatusMappingsQuery, List<CourierStatusMappingDto>>
        {
            private readonly IReadRepository<CourierStatusMapping> _courierStatusMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierStatusMapping> courierStatusMappingReadRepository, IMapper mapper)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierStatusMappingDto>> Handle(GetCourierStatusMappingsQuery request, CancellationToken cancellationToken)
            {
                var courierStatusMappings = await _courierStatusMappingReadRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierStatusMappingDto>>(courierStatusMappings);
            }
        }
    }
}