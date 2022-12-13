using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.Kbk.Dtos
{
    public class KbkCreateOrderRequest
    {
        public string apiCode { get; set; }
        public string postexShipmentCode { get; set; }
        public string senderName { get; set; }
        public string senderPhone { get; set; }
        public string senderAddr { get; set; }
        public string receiverName { get; set; }
        public string receiverPhone { get; set; }
        public string receiverAddr { get; set; }
        public int originCity { get; set; }
        public int destinationCity { get; set; }
        public List<KbkPriceDetailsResponse> Detail { get; set; }
    }
    public class KbkPriceDetailsResponse
    {
        public int size { get; set; }
        public int count { get; set; }
        public string desc { get; set; }
    }
}
