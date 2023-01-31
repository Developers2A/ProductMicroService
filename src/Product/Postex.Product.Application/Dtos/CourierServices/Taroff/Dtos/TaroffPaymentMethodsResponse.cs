namespace Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffPaymentMethodsResponse
    {
        public string State { get; set; }
        public List<TaroffState> Items { get; set; }
    }
}
