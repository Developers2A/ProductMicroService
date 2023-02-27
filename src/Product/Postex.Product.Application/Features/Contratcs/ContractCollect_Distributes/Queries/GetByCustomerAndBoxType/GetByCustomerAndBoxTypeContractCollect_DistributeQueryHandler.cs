using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByCustomerAndBoxType
{
    public class GetByCustomerAndBoxTypeContractCollect_DistributeQueryHandler : IRequestHandler<GetByCustomerAndBoxTypeContractCollect_DistributeQuery, CollectionDistributionPriceDto>
    {
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;


        public GetByCustomerAndBoxTypeContractCollect_DistributeQueryHandler(IReadRepository<ContractCollectionDistribution> readRepository)
        {
            _readRepository = readRepository;

        }
        public async Task<CollectionDistributionPriceDto> Handle(GetByCustomerAndBoxTypeContractCollect_DistributeQuery request, CancellationToken cancellationToken)
        {

            var collect_DistributeDefualt = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && ((c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0) || (c.ContractInfo.CityId == request.CityId && c.ContractInfo.ProvinceId == request.ProvinceId)) && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
              .Select(c => new CollectionDistributionPriceDto
              {
                  BoxTypeId = c.BoxTypeId,
                  ContractId = c.ContractInfoId,
                  ContractCollect_DistibuteId = c.Id,
                  DefaultSalePrice = c.SalePrice,
                  DefaultBuyPrice = c.BuyPrice,
                  ContractLevel = $"Default{(c.CityId == 0 ? "Province" : "City")}"
              })
              .FirstOrDefaultAsync(cancellationToken);




            var CusCity = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ProvinceId == request.ProvinceId && c.CityId == request.CityId
                                             && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
            .Select(c => new CollectionDistributionPriceDto
            {
                BoxTypeId = c.BoxTypeId,
                ContractId = c.ContractInfoId,
                ContractCollect_DistibuteId = c.Id,
                ContractSalePrice = c.SalePrice,
                ContractBuyPrice = c.BuyPrice,
                ContractLevel = "CustomerCity"
            })
               .FirstOrDefaultAsync(cancellationToken);

            if (CusCity != null)
            {
                if (collect_DistributeDefualt != null)
                {
                    collect_DistributeDefualt.ContractId = CusCity.ContractId;
                    collect_DistributeDefualt.ContractCollect_DistibuteId = CusCity.ContractCollect_DistibuteId;
                    collect_DistributeDefualt.ContractSalePrice = CusCity.ContractSalePrice;
                    collect_DistributeDefualt.ContractBuyPrice = CusCity.ContractBuyPrice;
                    collect_DistributeDefualt.ContractLevel = CusCity.ContractLevel;
                    return collect_DistributeDefualt;
                }
                else
                {
                    CusCity.DefaultSalePrice = 0;
                    CusCity.DefaultBuyPrice = 0;
                    return CusCity;
                }
            }

            var CusProvince = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ProvinceId == request.ProvinceId && c.CityId == 0
                                              && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
                .Select(c => new CollectionDistributionPriceDto
                {
                    BoxTypeId = c.BoxTypeId,
                    ContractId = c.ContractInfoId,
                    ContractCollect_DistibuteId = c.Id,
                    ContractSalePrice = c.SalePrice,
                    ContractBuyPrice = c.BuyPrice,
                    ContractLevel = "CustomerProvince"
                })
               .FirstOrDefaultAsync(cancellationToken);
            if (CusProvince != null)
            {
                if (collect_DistributeDefualt != null)
                {
                    collect_DistributeDefualt.ContractId = CusProvince.ContractId;
                    collect_DistributeDefualt.ContractCollect_DistibuteId = CusProvince.ContractCollect_DistibuteId;
                    collect_DistributeDefualt.ContractSalePrice = CusProvince.ContractSalePrice;
                    collect_DistributeDefualt.ContractBuyPrice = CusProvince.ContractBuyPrice;
                    collect_DistributeDefualt.ContractLevel = CusProvince.ContractLevel;
                    return collect_DistributeDefualt;
                }
                else
                {
                    CusProvince.DefaultSalePrice = 0;
                    CusProvince.DefaultBuyPrice = 0;
                    return CusProvince;
                }
            }

            var Cus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ProvinceId == 0 && c.CityId == 0
                                             && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
               .Select(c => new CollectionDistributionPriceDto
               {
                   BoxTypeId = c.BoxTypeId,
                   ContractId = c.ContractInfoId,
                   ContractCollect_DistibuteId = c.Id,
                   ContractSalePrice = c.SalePrice,
                   ContractBuyPrice = c.BuyPrice,
                   ContractLevel = "Customer"
               })
               .FirstOrDefaultAsync(cancellationToken);

            if (Cus != null)
            {
                if (collect_DistributeDefualt != null)
                {
                    collect_DistributeDefualt.ContractId = Cus.ContractId;
                    collect_DistributeDefualt.ContractCollect_DistibuteId = Cus.ContractCollect_DistibuteId;
                    collect_DistributeDefualt.ContractSalePrice = Cus.ContractSalePrice;
                    collect_DistributeDefualt.ContractBuyPrice = Cus.ContractBuyPrice;
                    collect_DistributeDefualt.ContractLevel = Cus.ContractLevel;
                    return collect_DistributeDefualt;
                }
                else
                {
                    Cus.DefaultSalePrice = 0;
                    Cus.DefaultBuyPrice = 0;
                    return Cus;
                }
            }

            return collect_DistributeDefualt;



        }
    }
}
