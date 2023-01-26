namespace Postex.Product.Application.Dtos.CourierServices.Post
{
    public class PostDeleteOrderResponse
    {
        public string ParcelCode { get; set; }
        public byte Result { get; set; }
        public bool RefundRes { get; set; }
    }
}
