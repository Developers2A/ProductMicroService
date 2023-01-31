using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class Basket
    {
        public List<BoxPrice> Parcels { get; set; }
        public CityTypeCode CityTypeCode { get; set; }
        public ServiceType ServiceCode { get; set; }
        public CourierCode CourierCode { get; set; }
        public string BasketId { get; set; }

        public Basket()
        {
            Parcels = new List<BoxPrice>();
        }
    }
}