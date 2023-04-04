using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.ValueAddeds;
using Postex.Product.Domain.Common;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ValueAddedTypes.Queries
{
    public class GetValueAddedTypeByIdQuery : IRequest<ValueAddedTypeDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetValueAddedTypeByIdQuery, ValueAddedTypeDto>
        {
            private readonly IReadRepository<ValueAddedType> _valueAddedTypeTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<ValueAddedType> valueAddedTypeTypeRepository, IMapper mapper)
            {
                _valueAddedTypeTypeRepository = valueAddedTypeTypeRepository;
                _mapper = mapper;
            }

            public async Task<ValueAddedTypeDto> Handle(GetValueAddedTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var valueAddedType = await _valueAddedTypeTypeRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<ValueAddedTypeDto>(valueAddedType);
            }
        }
    }
}