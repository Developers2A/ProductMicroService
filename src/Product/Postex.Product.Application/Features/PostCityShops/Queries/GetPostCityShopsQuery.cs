using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Posts;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostCityShops.Queries
{
    public class GetPostCityShopsQuery : IRequest<List<PostCityShopDto>>
    {
        public int? CityCode { get; set; }

        public class Handler : IRequestHandler<GetPostCityShopsQuery, List<PostCityShopDto>>
        {
            private readonly IReadRepository<PostCityShop> _postCityShopRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostCityShop> postCityShopRepository, IMapper mapper)
            {
                _postCityShopRepository = postCityShopRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<PostCityShopDto>> Handle(GetPostCityShopsQuery request, CancellationToken cancellationToken)
            {
                var postCityShopQuery = _postCityShopRepository.TableNoTracking;
                if (request.CityCode.HasValue && request.CityCode > 0)
                {
                    postCityShopQuery = postCityShopQuery.Where(x => x.CityCode == request.CityCode);
                }
                var postShops = await postCityShopQuery.OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<PostCityShopDto>>(postShops);
            }
        }
    }
}