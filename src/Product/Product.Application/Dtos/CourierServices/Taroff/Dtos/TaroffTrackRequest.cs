namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffTrackRequest
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
