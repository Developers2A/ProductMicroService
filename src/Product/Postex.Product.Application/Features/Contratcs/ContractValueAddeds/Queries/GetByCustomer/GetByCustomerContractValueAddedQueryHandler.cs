using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomer
{
    public class GetByCustomerContractValueAddedQueryHandler : IRequestHandler<GetByCustomerContractValueAddedQuery, List<ContractValueAddedDto>>
    {
        private readonly IReadRepository<ContractValueAdded> _readRepository;

        public GetByCustomerContractValueAddedQueryHandler(IReadRepository<ContractValueAdded> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractValueAddedDto>> Handle(GetByCustomerContractValueAddedQuery request, CancellationToken cancellationToken)
        {
            var itemCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
               .Select(c => new ContractValueAddedDto
               {
                   ContractInfoId = c.ContractInfoId,
                   CourierId = c.CourierId,
                   ValueAddedTypeId = c.ValueAddedTypeId,
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
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null)
              .Select(c => new ContractValueAddedDto
              {
                  ContractInfoId = c.ContractInfoId,
                  CourierId = c.CourierId,
                  ValueAddedTypeId = c.ValueAddedTypeId,
                  ProvinceId = c.ProvinceId,
                  CityId = c.CityId,
                  IsActive = c.IsActive,
                  SalePrice = c.SalePrice,
                  BuyPrice = c.BuyPrice,
                  Description = c.Description,
                  LevelPrice = "City"
              })
              .ToListAsync(cancellationToken);

            var itemDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0)
           .Select(c => new ContractValueAddedDto
           {
               ContractInfoId = c.ContractInfoId,
               CourierId = c.CourierId,
               ValueAddedTypeId = c.ValueAddedTypeId,
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

                if (itemCus.Where(c => c.ValueAddedTypeId == item.ValueAddedTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = itemCus.Where(c => c.ValueAddedTypeId == item.ValueAddedTypeId)
                      .FirstOrDefault();
                    itemDefualt[i].SalePrice = cus.SalePrice;
                    itemDefualt[i].BuyPrice = cus.BuyPrice;
                    itemDefualt[i].LevelPrice = "Customer";
                }
                else if (itemCity.Where(c => c.ValueAddedTypeId == item.ValueAddedTypeId)
                    .FirstOrDefault() != null)
                {
                    var cus = itemCity.Where(c => c.ValueAddedTypeId == item.ValueAddedTypeId)
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
