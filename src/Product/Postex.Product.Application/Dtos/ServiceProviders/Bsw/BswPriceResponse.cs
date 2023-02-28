namespace Postex.Product.Application.Dtos.ServiceProviders.Bsw
{
    public class BswPriceResponse
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Countrycode { get; set; }
        public int ParcelType { get; set; }
        public int Price { get; set; }
        public string errorMessage { get; set; }
    }
}
