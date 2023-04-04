using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUser
{
    public class GetByUserContractBoxPriceQueryHandler : IRequestHandler<GetByUserContractBoxPriceQuery, List<ContractBoxPriceDto>>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByUserContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
        {
            _readRepository = readRepository;
        }
        /// <summary>
        /// بدست آوردن قیمت های فعال برای همه اندازه های باکس بر اساس مشتری 
        /// قیمت همه سایز های جعبه ها برگشت داده میشود
        /// برای هر سایز بسته قرارداد پیش فرض ، مشتری ، شهر ، استان بررسی میشود
        /// با اولویت  ابتدا قرارداد مشتری ، سپس قرارداد شهر ، بعد از آن قرارداد استان  در اخر قرارداد پیش فرض هر اندازه باکس بدست می آید
        /// </summary>     
        /// <returns>قیمت همه سایر های  جعبه  به عنوان خروجی برگشت داده میشود</returns>
        public async Task<List<ContractBoxPriceDto>> Handle(GetByUserContractBoxPriceQuery request, CancellationToken cancellationToken)
        {
            var boxPriceDefualt = await _readRepository.Table
              .Include(b => b.BoxType)
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0)
              .Select(c => new ContractBoxPriceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.ProvinceId,
                  UserId = c.UserId,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  BoxName = c.BoxType.Name,
                  Height = c.BoxType.Height,
                  Width = c.BoxType.Width,
                  Length = c.BoxType.Length,
                  Description = c.Description,
                  IsActive = c.IsActive,
                  LevelPrice = "Default"
              })
              .ToListAsync(cancellationToken);

            var boxPriceCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null)
              .Select(c => new ContractBoxPriceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.ProvinceId,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description
              })
              .ToListAsync(cancellationToken);

            var boxPriceProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.UserId == null)
             .Select(c => new ContractBoxPriceDto
             {
                 Id = c.Id,
                 ContractInfoId = c.ContractInfoId,
                 BoxTypeId = c.BoxTypeId,
                 CityId = c.CityId,
                 ProvinceId = c.ProvinceId,
                 SalePrice = c.SalePrice,
                 BuyPrice = c.BuyPrice,
                 Description = c.Description
             })
             .ToListAsync(cancellationToken);

            var boxPriceCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == request.UserId)
                .Select(c => new ContractBoxPriceDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    Description = c.Description
                })
                .ToListAsync(cancellationToken);

            for (int i = 0; i < boxPriceDefualt.Count; i++)
            {
                var item = boxPriceDefualt[i];

                if (boxPriceCus.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = boxPriceCus.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    boxPriceDefualt[i].SalePrice = cus.SalePrice;
                    boxPriceDefualt[i].BuyPrice = cus.BuyPrice;
                    boxPriceDefualt[i].LevelPrice = "Customer";

                }
                else if (boxPriceCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = boxPriceCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    boxPriceDefualt[i].SalePrice = cus.SalePrice;
                    boxPriceDefualt[i].BuyPrice = cus.BuyPrice;
                    boxPriceDefualt[i].LevelPrice = "City";

                }
                else if (boxPriceProvince.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = boxPriceCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    boxPriceDefualt[i].SalePrice = cus.SalePrice;
                    boxPriceDefualt[i].BuyPrice = cus.BuyPrice;
                    boxPriceDefualt[i].LevelPrice = "Province";
                }
            }
            return boxPriceDefualt;
        }
    }
}
