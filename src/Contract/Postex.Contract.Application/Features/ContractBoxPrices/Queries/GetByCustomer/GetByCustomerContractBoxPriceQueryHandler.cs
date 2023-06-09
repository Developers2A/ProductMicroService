﻿using MediatR;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;
using Postex.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractBoxPrices.Queries.GetByCustomer
{
    public class GetByCustomerContractBoxPriceQueryHandler : IRequestHandler<GetByCustomerContractBoxPriceQuery, List<ContractBoxPriceDto>>
    {
        private readonly IReadRepository<ContractBoxPrice> _readRepository;

        public GetByCustomerContractBoxPriceQueryHandler(IReadRepository<ContractBoxPrice> readRepository)
        {
            this._readRepository = readRepository;
        }
        public async Task<List<ContractBoxPriceDto>> Handle(GetByCustomerContractBoxPriceQuery request, CancellationToken cancellationToken)
        {
            var boxPriceDefualt = await _readRepository.Table
              .Include(b => b.BoxType)
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && (c.ContractInfo.CustomerId == null && c.ContractInfo.CityId == null && c.ContractInfo.ProvinceId == null))
              .Select(c => new ContractBoxPriceDto
              {
                  Id = c.Id,
                  ContractInfoId = c.ContractInfoId,
                  BoxTypeId = c.BoxTypeId,
                  CityId = c.CityId,
                  ProvinceId = c.ProvinceId,
                  CustomerId= c.CustomerId,
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
              .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.CustomerId == null)
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
                .Include(c => c.ContractInfo).Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CustomerId == request.CustomerId)
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
            }

            return boxPriceDefualt;

        }
    }
}
