namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos
{
    public class TaroffGetPriceResponse
    {
        public TaroffPrice Price { get; set; }
        public string State { get; set; }
    }

    public class TaroffPrice
    {
        public int Post { get; set; }
        public int Shipping { get; set; }
        public int Tax { get; set; }
    }
}
