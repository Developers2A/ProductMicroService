﻿namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ContractValueAddedDto
    {
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int ValueAddedTypeId { get; set; }
        public string ValueAddedTypeName { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public bool IsActive { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public string? Description { get; set; }

        public string LevelPrice { get; set; }
    }
}
