using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ValueAddedPrices.Queries
{
    public class GetValueAddedPricesQuery : IRequest<List<ValueAddedPriceDto>>
    {
        public class Handler : IRequestHandler<GetValueAddedPricesQuery, List<ValueAddedPriceDto>>
        {
            private readonly IReadRepository<ValueAddedPrice> _valueAddedPriceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<ValueAddedPrice> valueAddedPriceRepository, IMapper mapper)
            {
                _valueAddedPriceRepository = valueAddedPriceRepository;
                _mapper = mapper;
            }

            public async Task<List<ValueAddedPriceDto>> Handle(GetValueAddedPricesQuery request, CancellationToken cancellationToken)
            {
                var valueAddedPrices = await _valueAddedPriceRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<ValueAddedPriceDto>>(valueAddedPrices);
            }
        }
    }
}