namespace Postex.Product.Application.Dtos.ServiceProviders.Bsw
{
    public class BswPriceRequest
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Countrycode { get; set; }
        public int ParcelType { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool Status = true;
            string Message = "";
            if (Weight <= 0)
            {
                Status = false;
                Message = "Weight should be greater than zero";
            }

            if (string.IsNullOrEmpty(Countrycode))
            {
                Status = false;
                Message = "CountryCode is null";
            }

            if (ParcelType <= 0)
            {
                Status = false;
                Message = "ParcelType is null";
            }

            return (Status, Message);
        }
    }
}
