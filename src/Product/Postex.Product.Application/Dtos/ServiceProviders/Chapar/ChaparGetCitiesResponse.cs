namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar
{
    public class ChaparGetCitiesResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsGetCity Objects { get; set; }
    }

    public class ChaparCity
    {
        public string state_no { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
    }

    public class ObjectsGetCity
    {
        public List<ChaparCity> city { get; set; }
    }
}
