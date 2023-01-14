﻿using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractBoxTypes.Command.Create
{
    public class CreateContractBoxTypeCommand : ITransactionRequest
    {
        public int BoxTypeId { get; set; }
        public int ContractInfoId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }

        public string Description { get; set; }

    }
}
