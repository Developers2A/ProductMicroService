using Postex.SharedKernel.Common.Enums;

namespace Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class Basket
    {
        public List<BoxPrice> Parcels { get; set; }
        public CityTypeCode CityTypeId { get; set; }
        public ServiceType ServiceId { get; set; }
        public CourierCode CourierId { get; set; }
        public string BasketId { get; set; }

        public Basket()
        {
            Parcels = new List<BoxPrice>();
        }
    }
}