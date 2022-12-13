using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.PostShops;
using Product.Domain.Posts;

namespace Product.Application.Features.PostShops.Queries
{
    public class GetPostShopByCityCodeQuery : IRequest<PostShopDto>
    {
        public int CityCode { get; set; }

        public class Handler : IRequestHandler<GetPostShopByCityCodeQuery, PostShopDto>
        {
            private readonly IReadRepository<PostShop> _postShopRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostShop> courierRepository, IMapper mapper)
            {
                _postShopRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<PostShopDto> Handle(GetPostShopByCityCodeQuery request, CancellationToken cancellationToken)
            {
                var postShop = await _postShopRepository.TableNoTracking.FirstOrDefaultAsync(c => c.CityCode == request.CityCode, cancellationToken);
                return _mapper.Map<PostShopDto>(postShop);
            }
        }
    }
}