﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCods.Queries
{
    public class GetCourierCodByIdQuery : IRequest<CourierCodDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierCodByIdQuery, CourierCodDto>
        {
            private readonly IReadRepository<CourierCod> _courierCodReadRepository;
            private readonly IMapper _mapper;
            public Handler(IReadRepository<CourierCod> courierCodReadRepository, IMapper mapper)
            {
                _courierCodReadRepository = courierCodReadRepository;
                _mapper = mapper;
            }

            public async Task<CourierCodDto> Handle(GetCourierCodByIdQuery request, CancellationToken cancellationToken)
            {
                var courierCod = await _courierCodReadRepository.TableNoTracking
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierCodDto>(courierCod);
            }
        }
    }
}