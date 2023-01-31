using AutoMapper;
using MediatR;
using Postex.Product.Application.Features.PostCityShops.Queries;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostShops.Queries
{
    public class GetPostShopIdQuery : IRequest<int>
    {
        public int? CityCode { get; set; }
        public string? Mobile { get; set; }

        public class Handler : IRequestHandler<GetPostShopIdQuery, int>
        {
            private readonly IMediator _mediator;

            public Handler(IReadRepository<PostShop> postShopRepository, IMapper mapper, IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<int> Handle(GetPostShopIdQuery request, CancellationToken cancellationToken)
            {
                var shop = await _mediator.Send(new GetPostShopsQuery()
                {
                    CityCode = string.IsNullOrEmpty(request.Mobile) ? request.CityCode : null,
                    Mobile = request.Mobile
                });

                if (shop != null && shop.Any())
                {
                    return shop.FirstOrDefault()!.ShopId;
                }
                else
                {
                    var cityShop = await _mediator.Send(new GetPostCityShopsQuery()
                    {
                        CityCode = request.CityCode,
                    });

                    if (cityShop != null && cityShop.Any())
                    {
                        return cityShop.FirstOrDefault()!.ShopId;
                    }
                }
                return 0;
            }
        }
    }
}