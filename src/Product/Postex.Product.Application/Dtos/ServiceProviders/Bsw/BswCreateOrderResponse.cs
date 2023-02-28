namespace Postex.Product.Application.Dtos.ServiceProviders.Bsw
{
    public class BswCreateOrderResponse
    {
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public object SenderPostCode { get; set; }
        public string SenderPhone { get; set; }
        public object SenderEmail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public object ReceiverPostCode { get; set; }
        public string ReceiverPhone { get; set; }
        public object ReceiverEmail { get; set; }
        public object Content { get; set; }
        public int ContentValue { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Countrycode { get; set; }
        public int ParcelType { get; set; }
        public int Price { get; set; }
        public string OrderNumber { get; set; }
        public string errorMessage { get; set; }
    }
}
