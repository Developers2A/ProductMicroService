﻿using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Update
{
    public class UpdateContractBoxPriceCommand : ITransactionRequest<ContractBoxPriceDto>
    {
        public int Id { get; set; }
        public int BoxTypeId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? CustomerId { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
