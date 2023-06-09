﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimits.Queries
{
    public class GetCourierLimitsQuery : IRequest<List<CourierLimitDto>>
    {
        public class Handler : IRequestHandler<GetCourierLimitsQuery, List<CourierLimitDto>>
        {
            private readonly IReadRepository<CourierLimit> _courierLimitReadRepository;

            public Handler(IReadRepository<CourierLimit> courierLimitReadRepository)
            {
                _courierLimitReadRepository = courierLimitReadRepository;
            }

            public async Task<List<CourierLimitDto>> Handle(GetCourierLimitsQuery request, CancellationToken cancellationToken)
            {
                var courierLimits = await _courierLimitReadRepository.TableNoTracking
                    .Select(c => new CourierLimitDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CreatedOn = c.CreatedOn
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierLimits;
            }
        }
    }
}