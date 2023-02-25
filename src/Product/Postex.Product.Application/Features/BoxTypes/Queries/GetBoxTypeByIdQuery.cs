using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxTypes.Queries
{
    public class GetBoxTypeByIdQuery : IRequest<BoxTypeDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetBoxTypeByIdQuery, BoxTypeDto>
        {
            private readonly IReadRepository<BoxType> _boxTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<BoxType> boxTypeRepository, IMapper mapper)
            {
                _boxTypeRepository = boxTypeRepository;
                _mapper = mapper;
            }

            public async Task<BoxTypeDto> Handle(GetBoxTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var boxPrice = await _boxTypeRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<BoxTypeDto>(boxPrice);
            }
        }
    }
}