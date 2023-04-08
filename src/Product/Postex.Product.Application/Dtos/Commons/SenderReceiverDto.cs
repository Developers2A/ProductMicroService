using Postex.Product.Application.Dtos.Commons.CreateParcel.Request;

namespace Postex.Product.Application.Dtos.Commons
{
    public class SenderReceiverDto
    {
        public ContactDto Contact { get; set; }
        public LocationDto Location { get; set; }
    }
}
