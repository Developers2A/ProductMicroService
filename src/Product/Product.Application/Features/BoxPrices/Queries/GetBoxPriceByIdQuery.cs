using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.BoxPrices.Queries
{
    public class GetBoxPriceByIdQuery : IRequest<BoxPriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetBoxPriceByIdQuery, BoxPriceDto>
        {
            private readonly IReadRepository<BoxPrice> _boxPriceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<BoxPrice> boxPriceRepository, IMapper mapper)
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