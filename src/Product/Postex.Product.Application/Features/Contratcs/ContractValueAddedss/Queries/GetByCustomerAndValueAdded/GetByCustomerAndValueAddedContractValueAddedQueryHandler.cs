using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ContractValueAddeds.Queries 
{
    public class GetByCustomerAndValueAddedContractValueAddedQueryHandler : IRequestHandler<GetByCustomerAndValueAddedContractValueAddedQuery, List<ContractValueAddedDto>>
    {
        private readonly IReadRepository<ContractValueAdded> _readRepository;

        public GetByCustomerAndValueAddedContractValueAddedQueryHandler(IReadRepository<ContractValueAdded> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractValueAddedDto>> Handle(GetByCustomerAndValueAddedContractValueAddedQuery request, CancellationToken cancellationToken)
        {
            var itemCus = await _readRepository.Table
               .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
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
            if (itemCus.Count != 0)
                return itemCus;

            var itemCity = await _readRepository.Table
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
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
            if (itemCity.Count != 0)
                return itemCity;

            var itemProvince = await _readRepository.Table
             .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.CustomerId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
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
                 LevelPrice = "Province"
             })
             .ToListAsync(cancellationToken);
            if (itemProvince.Count != 0)
                return itemProvince;

            var itemDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == 0 && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ValueAddedTypeId == request.ValueAddedId)
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


           

            return itemDefualt;

        }
    }
}
