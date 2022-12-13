using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.PostexCods.Queries
{
    public class GetPostexCodsQuery : IRequest<List<PostexCodDto>>
    {
        public class Handler : IRequestHandler<GetPostexCodsQuery, List<PostexCodDto>>
        {
            private readonly IReadRepository<PostexCod> _courierCodReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostexCod> courierCodReadRepository, IMapper mapper)
            {
                _courierCodReadRepository = courierCodReadRepository;
                _mapper = mapper;
            }

            public async Task<List<PostexCodDto>> Handle(GetPostexCodsQuery request, CancellationToken cancellationToken)
            {
                var postexCods = await _courierCodReadRepository.TableNoTracking
                    .OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
                return _mapper.Map<List<PostexCodDto>>(postexCods);
            }
        }
    }
}