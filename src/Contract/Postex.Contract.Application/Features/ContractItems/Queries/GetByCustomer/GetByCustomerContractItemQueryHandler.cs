using MediatR;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractItems.Queries.GetByCustomer
{
    public class GetByCustomerContractItemQueryHandler : IRequestHandler<GetByCustomerContractItemQuery, List<ContractItemDto>>
    {
        private readonly IReadRepository<ContractItem> _readRepository;

        public GetByCustomerContractItemQueryHandler(IReadRepository<ContractItem> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractItemDto>> Handle(GetByCustomerContractItemQuery request, CancellationToken cancellationToken)
        {
            var itemCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
               .Select(c => new ContractItemDto
               {
                   ContractInfoId = c.ContractInfoId,
                   CourierId = c.CourierId,
                   ContractItemTypeId = c.ContractItemTypeId,
                   ContractTypeCode = c.ContractItemType.ContractTypeCode,
                   ContractTypeName = c.ContractItemType.ContractTypeName,
                   ProvinceId = c.ProvinceId,
                   CityId = c.CityId,
                   IsActive = c.IsActive,
                   SalePrice = c.SalePrice,
                   BuyPrice = c.BuyPrice,
                   Description = c.Description,
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);
                    

            var itemCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null )
              .Select(c => new ContractItemDto
              {
                  ContractInfoId = c.ContractInfoId,
                  CourierId = c.CourierId,
                  ContractItemTypeId = c.ContractItemTypeId,
                  ContractTypeCode = c.ContractItemType.ContractTypeCode,
                  ContractTypeName = c.ContractItemType.ContractTypeName,
                  ProvinceId = c.ProvinceId,
                  CityId = c.CityId,
                  IsActive = c.IsActive,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description,
                  LevelPrice ="City"
              })
              .ToListAsync(cancellationToken);
            
            var itemDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && (c.ContractInfo.CustomerId == null && c.ContractInfo.CityId == null && c.ContractInfo.ProvinceId == null))
           .Select(c => new ContractItemDto
           {
               ContractInfoId = c.ContractInfoId,
               CourierId = c.CourierId,
               ContractItemTypeId = c.ContractItemTypeId,
               ContractTypeCode = c.ContractItemType.ContractTypeCode,
               ContractTypeName = c.ContractItemType.ContractTypeName,
               ProvinceId = c.ProvinceId,
               CityId = c.CityId,
               IsActive = c.IsActive,
               SalePrice = c.SalePrice,
               BuyPrice = c.BuyPrice,
               Description = c.Description,
               LevelPrice = "Default"

           })
           .ToListAsync(cancellationToken);


            for (int i = 0; i < itemDefualt.Count; i++)
            {
                var item = itemDefualt[i];

                if (itemCus.Where(c => c.ContractItemTypeId == item.ContractItemTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = itemCus.Where(c => c.ContractItemTypeId == item.ContractItemTypeId)
                      .FirstOrDefault();
                    itemDefualt[i].SalePrice = cus.SalePrice;
                    itemDefualt[i].BuyPrice = cus.BuyPrice;
                    itemDefualt[i].LevelPrice = "Customer";

                }
                else if (itemCity.Where(c => c.ContractItemTypeId == item.ContractItemTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = itemCity.Where(c => c.ContractItemTypeId == item.ContractItemTypeId)
                      .FirstOrDefault();
                    itemDefualt[i].SalePrice = cus.SalePrice;
                    itemDefualt[i].BuyPrice = cus.BuyPrice;
                    itemDefualt[i].LevelPrice = "City";

                }
            }

            return itemDefualt;

        }
    }
}
