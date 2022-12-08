namespace Product.Application.Dtos.Post
{
    public class PostDeleteOrderResponse
    {
        public string ParcelCode { get; set; }
        public byte Result { get; set; }
        public bool RefundRes { get; set; }
    }
}
