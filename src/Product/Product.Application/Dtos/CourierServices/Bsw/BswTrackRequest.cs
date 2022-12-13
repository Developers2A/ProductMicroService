namespace Product.Application.Dtos.CourierServices.Bsw
{
    public class BswTrackRequest
    {
        public string OrderNumber { get; set; }
        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((OrderNumber ?? "").Trim()))
            {
                return new(false, "OrderNumber is required");
            }
            return (status, message);
        }
    }
}
