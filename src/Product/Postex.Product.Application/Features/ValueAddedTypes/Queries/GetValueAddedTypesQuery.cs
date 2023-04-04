using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.ValueAddeds;
using Postex.Product.Domain.Common;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ValueAddedTypes.Queries
{
    public class GetValueAddedTypesQuery : IRequest<List<ValueAddedTypeDto>>
    {
        public class Handler : IRequestHandler<GetValueAddedTypesQuery, List<ValueAddedTypeDto>>
        {
            private readonly IReadRepository<ValueAddedType> _valueAddedTypeTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<ValueAddedType> valueAddedTypeTypeRepository, IMapper mapper)
            {
                _valueAddedTypeTypeRepository = valueAddedTypeTypeRepository;
                _mapper = mapper;
            }

            public async Task<List<ValueAddedTypeDto>> Handle(GetValueAddedTypesQuery request, CancellationToken cancellationToken)
            {
                var valueAddedTypes = await _valueAddedTypeTypeRepository.TableNoTracking
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<ValueAddedTypeDto>>(valueAddedTypes);
            }
        }
    }
}