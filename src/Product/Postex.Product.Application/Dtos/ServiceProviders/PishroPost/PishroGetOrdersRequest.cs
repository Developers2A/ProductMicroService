namespace Postex.Product.Application.Dtos.ServiceProviders.PishroPost
{
    public class PishroGetOrdersRequest
    {
        public string Token { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerPostalCode { get; set; }
        public int PageSize { get; set; }
        public string FromPickupDate { get; set; }
        public string TillPickupDate { get; set; }
        public string OrderId { get; set; }
        public int OrderStatus { get; set; }
    }
}
