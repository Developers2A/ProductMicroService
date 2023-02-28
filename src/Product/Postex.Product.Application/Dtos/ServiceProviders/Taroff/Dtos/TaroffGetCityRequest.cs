namespace Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos
{
    public class TaroffGetCityRequest
    {
        public string Token { get; set; }
        public int ProvinceId { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (ProvinceId <= 0)
            {
                return new(false, "ProvinceId must be greater than zero");
            }
            return (status, message);
        }

    }
}
