using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.PostShops;
using Product.Domain.Posts;

namespace Product.Application.Features.PostShops.Queries
{
    public class GetPostShopsQuery : IRequest<List<PostShopDto>>
    {
        public string? Mobile { get; set; }

        public class Handler : IRequestHandler<GetPostShopsQuery, List<PostShopDto>>
        {
            private readonly IReadRepository<PostShop> _postShopRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostShop> courierRepository, IMapper mapper)
            {
                _postShopRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<PostShopDto>> Handle(GetPostShopsQuery request, CancellationToken cancellationToken)
            {
                var postShopQuery = _postShopRepository.TableNoTracking;
                if (!string.IsNullOrEmpty(request.Mobile))
                {
                    postShopQuery = postShopQuery.Where(x => x.Mob == request.Mobile);
                }
                var postShops = await postShopQuery.OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<PostShopDto>>(postShops);
            }
        }
    }
}