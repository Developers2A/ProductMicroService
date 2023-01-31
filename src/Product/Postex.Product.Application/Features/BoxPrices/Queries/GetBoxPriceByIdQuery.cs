using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxPrices.Queries
{
    public class GetBoxPriceByIdQuery : IRequest<BoxPriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetBoxPriceByIdQuery, BoxPriceDto>
        {
            private readonly IReadRepository<BoxSizePrice> _boxPriceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<BoxSizePrice> boxPriceRepository, IMapper mapper)
            {
                _boxPriceRepository = boxPriceRepository;
                _mapper = mapper;
            }

            public async Task<BoxPriceDto> Handle(GetBoxPriceByIdQuery request, CancellationToken cancellationToken)
            {
                var boxPrice = await _boxPriceRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<BoxPriceDto>(boxPrice);
            }
        }
    }
}