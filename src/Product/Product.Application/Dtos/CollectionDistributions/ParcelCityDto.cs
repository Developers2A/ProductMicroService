﻿using Postex.SharedKernel.Common.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class ParcelCityDto
    {
        public int Id { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode CityType { get; set; }
        public double Volume { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
