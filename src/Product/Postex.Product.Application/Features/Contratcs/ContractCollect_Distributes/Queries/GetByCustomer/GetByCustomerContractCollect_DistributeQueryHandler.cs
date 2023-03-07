using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByCustomer
{
    public class GetByCustomerContractCollect_DistributeQueryHandler : IRequestHandler<GetByCustomerContractCollect_DistributeQuery, List<ContractCollectionDistributionDto>>
    {
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;


        public GetByCustomerContractCollect_DistributeQueryHandler(IReadRepository<ContractCollectionDistribution> readRepository)
        {
            _readRepository = readRepository;

        }
        /// <summary>
        /// قیمت توزیع و جمع آوری بر اساس نوع شهر ونوع کارتن متفاوت خواهد بود و این قیمت از سرویس مخصوص توزیع و جمع آوری بدست می آید
        /// در این بخش ما ممکن است برای یک مشتری خاص یا یک شهر و با یک استان بخواهیم قیمت توزیع و جمع آوری را بر اساس نوع کارتن ها مختلف تغییر دهیم

        /// در این متد بر اساس شناسه مشتری ، شهر و استان ، لیست قیمت های ثبت شده توزیع و یا جمع آوری برای انواع اندازه های کارتن بدست می آید
        /// در این متد با اولویت مشتری ، شهر ، استان و عمومی قیمت هر نوع کارتن بدست می آید
        /// 
        /// فیلد های وردی در کلاس GetByCustomerContractCollect_DistributeQuery تعریف شده اند
        /// </summary>

        public async Task<List<ContractCollectionDistributionDto>> Handle(GetByCustomerContractCollect_DistributeQuery request, CancellationToken cancellationToken)
        {
            var collect_DistributeDefualt = await _readRepository.Table
               .Include(b => b.BoxType)
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.CourierServiceId == request.CourierServiceId && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.StateId == 0)
               .Select(c => new ContractCollectionDistributionDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   CourierServiceId = c.CourierServiceId,
                   BoxTypeId = c.BoxTypeId,
                   CityId = c.CityId,
                   ProvinceId = c.StateId,
                   SalePrice = c.SalePrice,
                   BuyPrice = c.BuyPrice,
                   BoxName = c.BoxType.Name,
                   Height = c.BoxType.Height,
                   Width = c.BoxType.Width,
                   Length = c.BoxType.Length,
                   Description = c.Description,
                   LevelPrice = "Default"

               })
               .ToListAsync(cancellationToken);

            var collect_DistributeCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.CourierServiceId == request.CourierServiceId && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null)
              .Select(c => new ContractCollectionDistributionDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  CourierServiceId = c.CourierServiceId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.StateId,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description,
                  IsActice = c.IsActice
              })
              .ToListAsync(cancellationToken);

            var collect_DistributeCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.CourierServiceId == request.CourierServiceId && c.ContractInfo.CustomerId == request.CustomerId)
                .Select(c => new ContractCollectionDistributionDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    CourierServiceId = c.CourierServiceId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.StateId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    Description = c.Description,
                    IsActice = c.IsActice
                })
                .ToListAsync(cancellationToken);

            var collect_DistributeProvince = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.CourierServiceId == request.CourierServiceId && c.ContractInfo.StateId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0)
              .Select(c => new ContractCollectionDistributionDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  CourierServiceId = c.CourierServiceId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.StateId,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description,
                  IsActice = c.IsActice
              })
              .ToListAsync(cancellationToken);

            for (int i = 0; i < collect_DistributeDefualt.Count; i++)
            {
                var item = collect_DistributeDefualt[i];

                if (collect_DistributeCus.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = collect_DistributeCus.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    if (cus != null)
                    {
                        collect_DistributeDefualt[i].SalePrice = cus.SalePrice;
                        collect_DistributeDefualt[i].BuyPrice = cus.BuyPrice;
                        collect_DistributeDefualt[i].LevelPrice = "Customer";
                    }

                }
                else if (collect_DistributeCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var city = collect_DistributeCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    if (city != null)
                    {
                        collect_DistributeDefualt[i].SalePrice = city.SalePrice;
                        collect_DistributeDefualt[i].BuyPrice = city.BuyPrice;
                        collect_DistributeDefualt[i].LevelPrice = "City";
                    }

                }
                else if (collect_DistributeProvince.Where(c => c.BoxTypeId == item.BoxTypeId)
                    .FirstOrDefault() != null)
                {
                    var province = collect_DistributeCity.Where(c => c.BoxTypeId == item.BoxTypeId)
                      .FirstOrDefault();
                    if (province != null)
                    {
                        collect_DistributeDefualt[i].SalePrice = province.SalePrice;
                        collect_DistributeDefualt[i].BuyPrice = province.BuyPrice;
                        collect_DistributeDefualt[i].LevelPrice = "Province";
                    }


                }
            }



            return collect_DistributeDefualt;
        }
    }
}
