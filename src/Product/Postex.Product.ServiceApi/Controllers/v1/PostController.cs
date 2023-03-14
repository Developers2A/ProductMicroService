using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.PostShops.Commands.SyncPostShops;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.CreateShop;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateOrder;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetNodes;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetShops;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetStatus;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetUnits;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.Track;
using Postex.Product.ServiceApi.Filters;
using Postex.SharedKernel.Api;

namespace Postex.Product.ServiceApi.Controllers.v1
{
    [ApiVersion("1")]
    [ApiKey]
    public class PostController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("units")]
        public async Task<ApiResult<List<PostGetUnitsResponse>>> GetUnits(GetPostUnitsQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostGetUnitsResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("nodes")]
        public async Task<ApiResult<List<PostGetNodesResponse>>> GetNodes(GetPostNodesQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostGetNodesResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("shops")]
        public async Task<ApiResult<PostGetShopsResponse>> GetShops(GetShopsQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostGetShopsResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("create-shop")]
        public async Task<ApiResult<PostCreateShopResponse>> CreateShop(CreatePostShopCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess && result.Data != null)
            {
                var createdShop = result.Data;
                //await _postShopService.Insert(new Domain.Couriers.PostShop()
                //{
                //    ShopId = createdShop.ShopID,
                //    AccountBank = createdShop.AccountBank,
                //    AccountBranchName = createdShop.AccountBranchName,
                //    CityCode = createdShop.CityID,
                //    AccountIban = createdShop.AccountIban,
                //    AccountNumber = createdShop.AccountNumber,
                //    CollectTypeID = createdShop.CollectTypeID,
                //    ContractEndDate = createdShop.ContractEndDate,
                //    Email = createdShop.Email,
                //    Enabled = createdShop.Enabled,
                //    ManagerBirthDate = createdShop.ManagerBirthDate,
                //    Mob = createdShop.Mob,
                //    ManagerNationalID = createdShop.ManagerNationalID,
                //    ManagerNationalIDSerial = createdShop.ManagerNationalIDSerial,
                //    Name = createdShop.Name,
                //    Phone = createdShop.Phone,
                //    PostalCode = createdShop.PostalCode,
                //    PostnodeID = createdShop.PostnodeID,
                //    WebSiteURL = createdShop.WebSiteURL,
                //});
            }

            return new ApiResult<PostCreateShopResponse>(result.IsSuccess, result.Data!, result.Message);
        }

        [HttpPost("price")]
        public async Task<ApiResult<PostGetPriceResponse>> GetPrice(GetPostPriceQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostGetPriceResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("create-order")]
        public async Task<ApiResult<PostCreateOrderResponse>> CreateOrder(CreatePostOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostCreateOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("edit-order")]
        public async Task<ApiResult<PostEditOrderResponse>> EditOrder(UpdatePostOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostEditOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("edit-weight")]
        public async Task<ApiResult<PostEditWeightResponse>> EditOrder(UpdatePostWeightCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostEditWeightResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("suspend-order")]
        public async Task<ApiResult<List<PostSuspendOrderResponse>>> SuspendOrder(List<string> parcelCodes)
        {
            var request = new SuspendPostOrderCommand()
            {
                ParcelCodes = parcelCodes
            };
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostSuspendOrderResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("delete-order")]
        public async Task<ApiResult<List<PostDeleteOrderResponse>>> DeleteOrder(List<string> parcelCodes)
        {
            DeletePostOrderCommand request = new()
            {
                ParcelCodes = parcelCodes
            };
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostDeleteOrderResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("readyToCollect")]
        public async Task<ApiResult<List<PostReadyToCollectResponse>>> ReadyToCollect(List<string> parcelCodes)
        {
            var request = new ReadyToCollectOrderCommand()
            {
                ParcelCodes = parcelCodes
            };
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostReadyToCollectResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("order-status")]
        public async Task<ApiResult<List<PostOrderStatusResponse>>> GetOrderStatus(List<string> parcelCodes)
        {
            var request = new GetPostStatusQuery()
            {
                ParcelCodes = parcelCodes
            };
            var result = await _mediator.Send(request);
            return new ApiResult<List<PostOrderStatusResponse>>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("track")]
        public async Task<ApiResult<PostTrackResponse>> Track(GetPostTrackQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<PostTrackResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("sync-shops")]
        public async Task<IActionResult> SyncShops()
        {
            var result = await _mediator.Send(new SyncPostShopsCommand()
            {
                FromDate = DateTime.Now.AddYears(-15),
                ToDate = DateTime.Now.AddYears(10),
            });
            return Ok();
        }
    }
}
