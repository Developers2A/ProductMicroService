using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Mahex.Common;
using System.Collections.Generic;
using System.Linq;

namespace Postex.Product.Application.Dtos.CourierServices.Mahex
{
    public class MahexGetPriceRequest
    {
        public MahexGetPriceRequest()
        {
            FromAddress = new MahexAddress();
            ToAddress = new MahexAddress();
            Parcels = new List<MahexGetPriceParcel>();
        }

        [JsonProperty("from_address")]
        public MahexAddress FromAddress { get; set; }

        [JsonProperty("to_address")]
        public MahexAddress ToAddress { get; set; }

        [JsonProperty("parcels")]
        public List<MahexGetPriceParcel> Parcels { get; set; }

        [JsonProperty("package_type")]
        public string PackageType { get; set; }

        [JsonProperty("declared_value")]
        public string DeclaredValue { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (Parcels.Any(x => x.Weight < 0.5M))
            {
                status = false;
                message += "Weight must be greater 500g. ";
            }

            if (string.IsNullOrEmpty((FromAddress.CityCode ?? "").Trim()))
            {
                status = false;
                message += "FromAddress CityCode is required. ";
            }

            if (string.IsNullOrEmpty((ToAddress.CityCode ?? "").Trim()))
            {
                status = false;
                message += "ToAddress CityCode is required. ";
            }
            return (status, message);
        }
    }
}
