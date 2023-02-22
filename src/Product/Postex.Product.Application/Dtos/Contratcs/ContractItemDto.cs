﻿using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos
{
    public class ContractItemDto
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int ContractItemTypeId { get; set; }
        public ValueAddedType ContractItemType { get; set; }
        public string ContractTypeName { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public string Description { get; set; }

        public string LevelPrice { get; set; }
    }
}