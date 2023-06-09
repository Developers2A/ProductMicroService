﻿using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.CollectionDistributionPrices
{
    public class CollectionDistributionPriceDto
    {
        public int Id { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode CityType { get; set; }
        public double Volume { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
