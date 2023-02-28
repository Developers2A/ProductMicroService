namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos
{
    public class TaroffPaymentMethodsResponse
    {
        public string State { get; set; }
        public List<TaroffState> Items { get; set; }
    }
}
