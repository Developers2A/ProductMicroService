using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostGetCityResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public PishroPostObjectsGetCity Objects { get; set; }
    }

    public class PishroPostCity
    {
        public string state_no { get; set; }
        public string no { get; set; }
        public string name { get; set; }
    }

    public class PishroPostObjectsGetCity
    {
        public List<PishroPostCity> city { get; set; }
    }
}
