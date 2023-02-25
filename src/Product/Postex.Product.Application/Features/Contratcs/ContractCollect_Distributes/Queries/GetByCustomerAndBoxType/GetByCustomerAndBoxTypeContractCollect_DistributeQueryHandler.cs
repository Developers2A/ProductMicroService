using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractCollect_Distributes.Queries
{
    public class GetByCustomerAndBoxTypeContractCollect_DistributeQueryHandler : IRequestHandler<GetByCustomerAndBoxTypeContractCollect_DistributeQuery, List<ContractCollectionDistributionDto>>
    {
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;


        public GetByCustomerAndBoxTypeContractCollect_DistributeQueryHandler(IReadRepository<ContractCollectionDistribution> readRepository)
        {
            this._readRepository = readRepository;

        }
        public async Task<List<ContractCollectionDistributionDto>> Handle(GetByCustomerAndBoxTypeContractCollect_DistributeQuery request, CancellationToken cancellationToken)
        {

            var collect_DistributeCus = await _readRepository.Table
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
                .Select(c => new ContractCollectionDistributionDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    Description = c.Description,
                    IsActice = c.IsActice,
                    LevelPrice = "Customer"
                })
                .ToListAsync(cancellationToken);
            if (collect_DistributeCus.Any())
                return collect_DistributeCus;



            var collect_DistributeCity = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
             .Select(c => new ContractCollectionDistributionDto
             {
                 Id = c.Id,
                 ContractInfoId = c.ContractInfoId,
                 BoxTypeId = c.BoxTypeId,
                 CityId = c.CityId,
                 ProvinceId = c.ProvinceId,
                 SalePrice = c.SalePrice,
                 BuyPrice = c.BuyPrice,
                 Description = c.Description,
                 IsActice = c.IsActice,
                 LevelPrice = "City"
             })
             .ToListAsync(cancellationToken);
            if (collect_DistributeCity.Any())
                return collect_DistributeCity;

            var collect_DistributeProvince = await _readRepository.Table
            .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
            .Select(c => new ContractCollectionDistributionDto
            {
                Id = c.Id,
                ContractInfoId = c.ContractInfoId,
                BoxTypeId = c.BoxTypeId,
                CityId = c.CityId,
                ProvinceId = c.ProvinceId,
                SalePrice = c.SalePrice,
                BuyPrice = c.BuyPrice,
                Description = c.Description,
                IsActice = c.IsActice,
                LevelPrice = "Province"
            })
            .ToListAsync(cancellationToken);
            if (collect_DistributeProvince.Any())
                return collect_DistributeProvince;

            var collect_DistributeDefualt = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now && c.BoxTypeId == request.BoxTypeId)
               .Select(c => new ContractCollectionDistributionDto
               {
                   Id = c.Id,
                   ContractInfoId = c.ContractInfoId,
                   BoxTypeId = c.BoxTypeId,
                   CityId = c.CityId,
                   ProvinceId = c.ProvinceId,
                   SalePrice = c.SalePrice,
                   BuyPrice = c.BuyPrice,
                   Description = c.Description,
                   LevelPrice = "Default"

               })
               .ToListAsync(cancellationToken);

            return collect_DistributeDefualt;



        }
    }
}
