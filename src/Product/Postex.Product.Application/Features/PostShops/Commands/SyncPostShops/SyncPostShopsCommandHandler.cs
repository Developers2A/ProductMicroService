using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetShops;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostShops.Commands.SyncPostShops
{
    public class SyncPostShopsCommandHandler : IRequestHandler<SyncPostShopsCommand>
    {
        private readonly IReadRepository<PostShop> _postShopReadRepository;
        private readonly IWriteRepository<PostShop> _postShopWriteRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SyncPostShopsCommandHandler(IWriteRepository<PostShop> postShopWriteRepository, IMapper mapper, IReadRepository<PostShop> postShopReadRepository, IMediator mediator)
        {
            _postShopWriteRepository = postShopWriteRepository ?? throw new ArgumentNullException(nameof(postShopWriteRepository));
            _postShopReadRepository = postShopReadRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SyncPostShopsCommand request, CancellationToken cancellationToken)
        {
            var existingPostshops = await _postShopReadRepository.Table.ToListAsync();

            for (int i = 1; i < 60; i++)
            {
                var postShops = await GetPostShops(request.FromDate, request.ToDate, true, i);

                if (postShops != null)
                {
                    await InsertOrUpdatePostShops(existingPostshops, postShops);
                }
            }

            return Unit.Value;
        }

        private async Task InsertOrUpdatePostShops(List<PostShop> existingPostshops, IEnumerable<Shop> postShops)
        {
            var updatedShops = new List<PostShop>();
            var insertedShops = new List<PostShop>();
            try
            {
                foreach (var item in postShops)
                {
                    var existingPostshop = existingPostshops.FirstOrDefault(x => x.ShopId == item.ID);
                    if (existingPostshop != null)
                    {
                        var id = existingPostshop.Id;
                        _mapper.Map(item, existingPostshop);
                        existingPostshop.ModifiedOn = DateTime.Now;
                        existingPostshop.Id = id;
                        updatedShops.Add(existingPostshop);
                    }
                    else
                    {
                        PostShop newPostShop = new();
                        _mapper.Map(item, newPostShop);
                        newPostShop.Id = 0;
                        insertedShops.Add(newPostShop);
                    }
                }

                if (insertedShops.Any())
                {
                    await _postShopWriteRepository.AddRangeAsync(insertedShops);
                }
                if (updatedShops.Any())
                {
                    await _postShopWriteRepository.UpdateRangeAsync(updatedShops);
                }
                await _postShopWriteRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        private async Task<List<Shop>?> GetPostShops(DateTime from, DateTime to, bool enabled, int page)
        {
            BaseResponse<PostGetShopsResponse> shopResponse = await GetShopsFromPostApi(from, to, enabled, page);

            if (!shopResponse.IsSuccess)
            {
                return null;
            }

            if (shopResponse.Data == null || !shopResponse.Data.DataItems.Any())
            {
                return null;
            }

            return shopResponse.Data.DataItems;
        }

        private async Task<BaseResponse<PostGetShopsResponse>> GetShopsFromPostApi(DateTime from, DateTime to, bool enabled, int page)
        {
            return await _mediator.Send(new GetShopsQuery()
            {
                FromContractEndDate = from,
                ToContractEndDate = to,
                Enabled = enabled,
                Name = "",
                Page = page,
                PageSize = 100,
            });
        }
    }
}
