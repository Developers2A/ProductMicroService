using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostGetPriceResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("objects")]
        public PishroPostObject Objects { get; set; }
    }

    public class PishroPostObject
    {
        [JsonProperty("order")]
        public PishroPostOrderResponser Order { get; set; }
    }

    public class PishroPostOrderResponser
    {
        [JsonProperty("price")]
        public PishroPostPrice Price { get; set; }

        [JsonProperty("quote")]
        public int Quote { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PishroPostPrice
    {
        [JsonProperty("zone")]
        public object Zone { get; set; }

        [JsonProperty("fld_Manual_Cost")]
        public int FldManualCost { get; set; }

        [JsonProperty("fld_Pack_Cost")]
        public int FldPackCost { get; set; }

        [JsonProperty("fld_Charge_Cost")]
        public int FldChargeCost { get; set; }

        [JsonProperty("fld_Manual_Insurance")]
        public int FldManualInsurance { get; set; }

        [JsonProperty("fld_Lab_Cost")]
        public int FldLabCost { get; set; }

        [JsonProperty("fld_Agency_Cost_From")]
        public object FldAgencyCostFrom { get; set; }

        [JsonProperty("fld_Agency_Cost")]
        public object FldAgencyCost { get; set; }

        [JsonProperty("fld_Manual_VAT")]
        public int FldManualVAT { get; set; }

        [JsonProperty("fld_Total_Cost")]
        public int FldTotalCost { get; set; }
    }
}
