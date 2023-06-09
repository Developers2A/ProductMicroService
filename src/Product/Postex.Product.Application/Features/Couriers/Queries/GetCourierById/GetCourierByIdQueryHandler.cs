﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Couriers.Queries.GetCourierById
{
    public class GetCourierByIdQueryHandler : IRequestHandler<GetCourierByIdQuery, CourierDto>
    {
        private readonly IReadRepository<Courier> _courierReadRepository;

        public GetCourierByIdQueryHandler(IReadRepository<Courier> courierRepository)
        {
            _courierReadRepository = courierRepository;
        }

        public async Task<CourierDto> Handle(GetCourierByIdQuery request, CancellationToken cancellationToken)
        {
            var courier = await _courierReadRepository.TableNoTracking
                .Select(c => new CourierDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return courier;
        }
    }
}
