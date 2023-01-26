using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CourierServices.Post;
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

        public SyncPostShopsCommandHandler(IWriteRepository<PostShop> postShopWriteRepository, IMapper mapper, IReadRepository<PostShop> postShopReadRepository, IMediator mediator)
        {
            _postShopWriteRepository = postShopWriteRepository ?? throw new ArgumentNullException(nameof(postShopWriteRepository));
            _postShopReadRepository = postShopReadRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SyncPostShopsCommand request, CancellationToken cancellationToken)
        {
            var existingPostshops = await _postShopReadRepository.TableNoTracking.ToListAsync();

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

        private async Task InsertOrUpdatePostShops(List<PostShop> existingPostshops, IEnumerable<PostShop> postShops)
        {
            var updatedShops = new List<PostShop>();
            var insertedShops = new List<PostShop>();

            foreach (var item in postShops)
            {
                var existingPostshop = existingPostshops.FirstOrDefault(x => x.ShopId == item.ShopId);
                if (existingPostshop != null)
                {
                    item.ModifiedOn = DateTime.Now;
                    item.Id = existingPostshop.Id;
                    item.CreatedOn = existingPostshop.CreatedOn;
                    updatedShops.Add(item);
                }
                else
                {
                    insertedShops.Add(item);
                }
            }
            await _postShopWriteRepository.AddRangeAsync(insertedShops);
            await _postShopWriteRepository.UpdateRangeAsync(updatedShops);
            await _postShopWriteRepository.SaveChangeAsync();
        }

        private async Task<List<PostShop>?> GetPostShops(DateTime from, DateTime to, bool enabled, int page)
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

            var postShops = shopResponse.Data.DataItems.Select(x => new PostShop()
            {
                ShopId = x.ID,
                AccountBank = x.AccountBank,
                AccountBranchName = x.AccountBranchName,
                CityCode = x.CityID,
                City = x.City,
                AccountIban = x.AccountIban,
                AccountNumber = x.AccountNumber,
                AdminAccepet = x.AdminAccepet,
                CollectTypeID = x.CollectTypeID,
                CompanyDiscountPercent = x.CompanyDiscountPercent,
                CompanyPricePlanID = x.CompanyPricePlanID,
                ContractEndDate = x.ContractEndDate,
                Email = x.Email,
                Enabled = x.Enabled,
                ManagerBirthDate = x.ManagerBirthDate,
                ManagerCertNumber = x.ManagerCertNumber,
                ManagerCertSerial = x.ManagerCertSerial,
                ManagerFatherName = x.ManagerFatherName,
                ManagerFirstName = x.ManagerFirstName,
                ManagerLastName = x.ManagerLastName,
                ManagerCertSeries = x.ManagerCertSeries,
                Mob = x.Mob,
                ManagerNationalID = x.ManagerNationalID,
                ManagerNationalIDSerial = x.ManagerNationalIDSerial,
                Name = x.Name,
                Phone = x.Phone,
                PostalCode = x.PostalCode,
                PostnodeID = x.PostnodeID,
                PostUnit = x.PostUnit,
                PostUnitID = x.PostUnitID,
                Province = x.Province,
                ProvinceCode = x.ProvinceID,
                ShopAddress = x.ShopAddress,
                ShopDiscountPercent = x.ShopDiscountPercent,
                Postnode = x.Postnode,
                WebSiteURL = x.WebSiteURL,
                PricePlanID = x.PricePlanID,
                ShopCreateDate = x.CreateDateTime,
            }).ToList();

            return postShops;
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
