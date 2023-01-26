using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.PostShops;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostShops.Queries
{
    public class GetPostShopByIdQuery : IRequest<PostShopDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPostShopByIdQuery, PostShopDto>
        {
            private readonly IReadRepository<PostShop> _postShopRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostShop> courierRepository, IMapper mapper)
            {
                _postShopRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<PostShopDto> Handle(GetPostShopByIdQuery request, CancellationToken cancellationToken)
            {
                var postShop = await _postShopRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<PostShopDto>(postShop);
            }
        }
    }
}