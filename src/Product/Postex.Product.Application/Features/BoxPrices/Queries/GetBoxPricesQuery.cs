using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxPrices.Queries
{
    public class GetBoxPricesQuery : IRequest<List<BoxPriceDto>>
    {
        public class Handler : IRequestHandler<GetBoxPricesQuery, List<BoxPriceDto>>
        {
            private readonly IReadRepository<BoxSizePrice> _boxPriceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<BoxSizePrice> boxPriceRepository, IMapper mapper)
            {
                _boxPriceRepository = boxPriceRepository;
                _mapper = mapper;
            }

            public async Task<List<BoxPriceDto>> Handle(GetBoxPricesQuery request, CancellationToken cancellationToken)
            {
                var boxPrices = await _boxPriceRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<BoxPriceDto>>(boxPrices);
            }
        }
    }
}