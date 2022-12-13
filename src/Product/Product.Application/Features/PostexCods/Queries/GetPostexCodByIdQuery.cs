using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.PostexCods.Queries
{
    public class GetPostexCodByIdQuery : IRequest<PostexCodDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPostexCodByIdQuery, PostexCodDto>
        {
            private readonly IReadRepository<PostexCod> _postexCodReadRepository;
            private readonly IMapper _mapper;
            public Handler(IReadRepository<PostexCod> postexCodReadRepository, IMapper mapper)
            {
                _postexCodReadRepository = postexCodReadRepository;
                _mapper = mapper;
            }

            public async Task<PostexCodDto> Handle(GetPostexCodByIdQuery request, CancellationToken cancellationToken)
            {
                var postexCod = await _postexCodReadRepository.TableNoTracking
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<PostexCodDto>(postexCod);
            }
        }
    }
}