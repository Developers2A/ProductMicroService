using System.Collections.Generic;

namespace Product.Application.Dtos.Chapar
{
    public class ChaparGetCityResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsGetCity Objects { get; set; }
    }

    public class ChaparCity
    {
        public string state_no { get; set; }
        public string no { get; set; }
        public string name { get; set; }
    }

    public class ObjectsGetCity
    {
        public List<ChaparCity> city { get; set; }
    }
}
