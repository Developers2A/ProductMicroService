namespace Postex.Product.Application.Dtos.ServiceProviders.Bsw
{
    public class BswTrackResponseDto
    {
        public string OrderNumber { get; set; }
        public string Location { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
    }
}