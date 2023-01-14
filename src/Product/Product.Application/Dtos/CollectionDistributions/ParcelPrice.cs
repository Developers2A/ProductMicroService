﻿using Postex.SharedKernel.Common.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class ParcelPrice
    {
        public string SizeOfBox { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal? CollectionPrice { get; set; } = 0;
        public decimal? DistributionPrice { get; set; } = 0;
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public CityTypeCode DestinationCityTypeId { get; set; }
        public string ShipmentId { get; set; }
        public bool IsNew { get; set; }
        public bool IsCanceled { get; set; }
        public bool NeedsCollection { get; set; }
        public bool NeedsDistribution { get; set; }
    }
}
