﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ValueAddedPrices.Queries
{
    public class GetValueAddedPriceByIdQuery : IRequest<ValueAddedPriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetValueAddedPriceByIdQuery, ValueAddedPriceDto>
        {
            private readonly IReadRepository<ValueAddedPrice> _boxPriceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<ValueAddedPrice> boxPriceRepository, IMapper mapper)
            {
                _boxPriceRepository = boxPriceRepository;
                _mapper = mapper;
            }

            public async Task<ValueAddedPriceDto> Handle(GetValueAddedPriceByIdQuery request, CancellationToken cancellationToken)
            {
                var boxPrice = await _boxPriceRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<ValueAddedPriceDto>(boxPrice);
            }
        }
    }
}