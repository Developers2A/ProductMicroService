using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxTypes.Queries
{
    public class GetBoxTypesQuery : IRequest<List<BoxTypeDto>>
    {
        public class Handler : IRequestHandler<GetBoxTypesQuery, List<BoxTypeDto>>
        {
            private readonly IReadRepository<BoxType> _boxTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<BoxType> boxTypeRepository, IMapper mapper)
            {
                _boxTypeRepository = boxTypeRepository;
                _mapper = mapper;
            }

            public async Task<List<BoxTypeDto>> Handle(GetBoxTypesQuery request, CancellationToken cancellationToken)
            {
                var boxTypes = await _boxTypeRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<BoxTypeDto>>(boxTypes);
            }
        }
    }
}