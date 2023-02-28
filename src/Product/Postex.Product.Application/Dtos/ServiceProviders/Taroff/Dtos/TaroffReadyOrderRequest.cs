namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos
{
    public class TaroffReadyOrderRequest
    {
        public string Token { get; set; }
        public int OrderId { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (OrderId <= 0)
            {
                return new(false, "OrderId must be greater than zero");
            }
            return (status, message);
        }

    }
}
