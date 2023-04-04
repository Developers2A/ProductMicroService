using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUserAndBoxType
{

    public class GetByUserAndBoxTypeContractBoxPriceQueryHandler : IRequestHandler<GetByUserAndBoxTypeContractBoxPriceQuery, BoxPriceDto>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByUserAndBoxTypeContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
        {
            _readRepository = readRepository;
        }
        /// <summary>
        /// بدست آوردن قیمت پیش فرض و قراردادی برای مشتری
        /// در صورتی که برای مشتری قرارداد مشخص و فعال داشته باشیم همراه با قیمت پیش فرض ، مبلغ قرارداد با مشتری بر گشت داده می شود
        /// در صورتی که مشتری قرارداد فعالی نداشته باشد ، ابتدا بر اساس شهر مشتری و در صورت نبود قرارداد برای شهر ، قرارداد استان نیز بررسی میشود
        /// </summary>     
        /// <returns>قیمت پیش فرض و قرارداد بر اساس یک سایز کارتن</returns>
        public async Task<BoxPriceDto> Handle(GetByUserAndBoxTypeContractBoxPriceQuery request, CancellationToken cancellationToken)
        {
            var boxPrice = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && (c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0) && c.BoxTypeId == request.BoxTypeId)
              .Select(c => new BoxPriceDto
              {
                  ContractId = c.ContractInfoId,
                  ContractBoxPriceId = c.Id,
                  BoxTypeId = c.BoxTypeId,
                  DefaultSalePrice = c.SalePrice,
                  DefaultBuyPrice = c.BuyPrice,
                  ContractLevel = "Default"

              })
              .FirstOrDefaultAsync(cancellationToken);

            var boxPriceCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.UserId == request.UserId && c.BoxTypeId == request.BoxTypeId)
                .Select(c => new BoxPriceDto
                {
                    ContractId = c.ContractInfoId,
                    ContractBoxPriceId = c.Id,
                    ContractSalePrice = c.SalePrice,
                    ContractBuyPrice = c.BuyPrice,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (boxPriceCus != null)
            {
                boxPrice.ContractId = boxPriceCus.ContractId;
                boxPrice.ContractBoxPriceId = boxPriceCus.ContractBoxPriceId;
                boxPrice.ContractSalePrice = boxPriceCus.ContractSalePrice;
                boxPrice.ContractBuyPrice = boxPriceCus.ContractBuyPrice;
                boxPrice.ContractLevel = "Customer";
                return boxPrice;
            }


            var boxPriceCity = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null && c.BoxTypeId == request.BoxTypeId)
            .Select(c => new BoxPriceDto
            {
                ContractId = c.ContractInfoId,
                ContractBoxPriceId = c.Id,
                ContractSalePrice = c.SalePrice,
                ContractBuyPrice = c.BuyPrice,
            })
             .FirstOrDefaultAsync(cancellationToken);

            if (boxPriceCity != null)
            {
                boxPrice.ContractId = boxPriceCity.ContractId;
                boxPrice.ContractBoxPriceId = boxPriceCity.ContractBoxPriceId;
                boxPrice.ContractSalePrice = boxPriceCity.ContractSalePrice;
                boxPrice.ContractBuyPrice = boxPriceCity.ContractBuyPrice;
                boxPrice.ContractLevel = "City";
                return boxPrice;
            }

            var boxPriceProvince = await _readRepository.Table
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.UserId == null && c.BoxTypeId == request.BoxTypeId)
            .Select(c => new BoxPriceDto
            {
                ContractId = c.ContractInfoId,
                ContractBoxPriceId = c.Id,
                ContractSalePrice = c.SalePrice,
                ContractBuyPrice = c.BuyPrice,
            })
            .FirstOrDefaultAsync(cancellationToken);

            if (boxPriceProvince != null)
            {
                boxPrice.ContractId = boxPriceProvince.ContractId;
                boxPrice.ContractBoxPriceId = boxPriceProvince.ContractBoxPriceId;
                boxPrice.ContractSalePrice = boxPriceProvince.ContractSalePrice;
                boxPrice.ContractBuyPrice = boxPriceProvince.ContractBuyPrice;
                boxPrice.ContractLevel = "Province";
                return boxPrice;
            }


            return boxPrice;

        }
    }
}
