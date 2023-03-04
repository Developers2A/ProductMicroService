using MediatR;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postex.Product.Domain.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomer
{
    public class GetByCustomerContractBoxPriceQueryHandler : IRequestHandler<GetByCustomerContractBoxPriceQuery, List<ContractBoxPriceDto>>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByCustomerContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
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
        public async Task<List<ContractBoxPriceDto>> Handle(GetByCustomerContractBoxPriceQuery request, CancellationToken cancellationToken)
        {
            var boxPriceDefualt = await _readRepository.Table
              .Include(b => b.BoxType)
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0)
              .Select(c => new ContractBoxPriceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.ProvinceId,
                  CustomerId = c.CustomerId,
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
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0)
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
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CustomerId == 0)
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
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CustomerId == request.CustomerId)
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
