using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomerAndValueAdded
{
    public class GetByCustomerAndValueAddedContractValueAddedQueryHandler : IRequestHandler<GetByCustomerAndValueAddedContractValueAddedQuery, ValueAddedPriceDto>
    {
        private readonly IReadRepository<ContractValueAdded> _readRepository;

        public GetByCustomerAndValueAddedContractValueAddedQueryHandler(IReadRepository<ContractValueAdded> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<ValueAddedPriceDto> Handle(GetByCustomerAndValueAddedContractValueAddedQuery request, CancellationToken cancellationToken)
        {
            var ValueAddedPrice = await _readRepository.TableNoTracking
             .Include(c => c.ContractInfo).Include(x => x.ValueAddedType).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
             .Select(c => new ValueAddedPriceDto
             {
                 ContractId = c.ContractInfoId,
                 ContractValueAddedId = c.Id,
                 ValueAddedTypeId = c.ValueAddedTypeId,
                 ValueAddedTypeName = c.ValueAddedType.Name,
                 DefaultSalePrice = c.SalePrice,
                 DefaultBuyPrice = c.BuyPrice,
                 ContractLevel = "Default"
             })
            .FirstOrDefaultAsync(cancellationToken);

            var itemCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
                .Select(c => new ValueAddedPriceDto
                {
                    ContractId = c.ContractInfoId,
                    ContractValueAddedId = c.Id,
                    ValueAddedTypeId = c.ValueAddedTypeId,
                    ValueAddedTypeName = c.ValueAddedType.Name,
                    DefaultSalePrice = c.SalePrice,
                    DefaultBuyPrice = c.BuyPrice
                })
               .FirstOrDefaultAsync(cancellationToken);

            if (itemCus != null)
            {
                ValueAddedPrice.ContractId = itemCus.ContractId;
                ValueAddedPrice.ContractValueAddedId = itemCus.ContractValueAddedId;
                ValueAddedPrice.ValueAddedTypeName = itemCus.ValueAddedTypeName;
                ValueAddedPrice.ContractSalePrice = itemCus.ContractSalePrice;
                ValueAddedPrice.ContractBuyPrice = itemCus.ContractBuyPrice;
                ValueAddedPrice.ContractLevel = "Customer";
                return ValueAddedPrice;
            }


            var itemCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
             .Select(c => new ValueAddedPriceDto
             {
                 ContractId = c.ContractInfoId,
                 ContractValueAddedId = c.Id,
                 ValueAddedTypeId = c.ValueAddedTypeId,
                 ValueAddedTypeName = c.ValueAddedType.Name,
                 DefaultSalePrice = c.SalePrice,
                 DefaultBuyPrice = c.BuyPrice
             })
               .FirstOrDefaultAsync(cancellationToken);
            if (itemCity != null)
            {
                ValueAddedPrice.ContractId = itemCity.ContractId;
                ValueAddedPrice.ContractValueAddedId = itemCity.ContractValueAddedId;
                ValueAddedPrice.ValueAddedTypeName = itemCity.ValueAddedTypeName;
                ValueAddedPrice.ContractSalePrice = itemCity.ContractSalePrice;
                ValueAddedPrice.ContractBuyPrice = itemCity.ContractBuyPrice;
                ValueAddedPrice.ContractLevel = "City";
                return ValueAddedPrice;
            }

            var itemProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
              .Select(c => new ValueAddedPriceDto
              {
                  ContractId = c.ContractInfoId,
                  ContractValueAddedId = c.Id,
                  ValueAddedTypeId = c.ValueAddedTypeId,
                  ValueAddedTypeName = c.ValueAddedType.Name,
                  DefaultSalePrice = c.SalePrice,
                  DefaultBuyPrice = c.BuyPrice
              })
               .FirstOrDefaultAsync(cancellationToken);
            if (itemProvince != null)
            {
                ValueAddedPrice.ContractId = itemProvince.ContractId;
                ValueAddedPrice.ContractValueAddedId = itemProvince.ContractValueAddedId;
                ValueAddedPrice.ValueAddedTypeName = itemProvince.ValueAddedTypeName;
                ValueAddedPrice.ContractSalePrice = itemProvince.ContractSalePrice;
                ValueAddedPrice.ContractBuyPrice = itemProvince.ContractBuyPrice;
                ValueAddedPrice.ContractLevel = "Province";
                return ValueAddedPrice;
            }

            return ValueAddedPrice;

        }
    }
}
