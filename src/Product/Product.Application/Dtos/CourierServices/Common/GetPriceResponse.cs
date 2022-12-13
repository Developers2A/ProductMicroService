using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.Common
{
    public class GetPriceResponse
    {
        public decimal CartonPrice { get; set; }
        public decimal InsurancePrice { get; set; }
        public decimal PrintPrice { get; set; }
        public decimal AvatarPrice { get; set; }
        public decimal SmsPrice { get; set; }
        public decimal CollectionPrice { get; set; }
        public decimal DistributionPrice { get; set; }
        public List<ServicePrice> ServicePrices { get; set; }
    }

    public class ServicePrice
    {
        public string CourierName { get; set; }
        public int CourierCode { get; set; }
        public long CourierTax { get; set; }
        public long DiscountAmount { get; set; }
        public long PostexPrice { get; set; }
        public long PostexTax { get; set; }
        public long TotalPrice { get; set; }
    }
}
