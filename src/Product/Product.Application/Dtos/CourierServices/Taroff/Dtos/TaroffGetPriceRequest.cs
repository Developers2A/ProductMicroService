namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffGetPriceRequest
    {
        public string Token { get; set; }
        public int CityId { get; set; }
        public int PaymentMethodId { get; set; }
        public int CarrierId { get; set; }
        public int TotalWeight { get; set; }
        public int TotalPrice { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (CityId <= 0)
            {
                status = false;
                message += "CityId must be greater than zero. ";
            }
            if (PaymentMethodId <= 0)
            {
                status = false;
                message += "PaymentMethodId must be greater than zero. Get it from /Taroff/payment-methods api. ";
            }
            if (CarrierId <= 0)
            {
                status = false;
                message += "CarrierId must be greater than zero. Get it from /Taroff//Taroff/carriers api. ";
            }
            return (status, message);
        }

    }
}
