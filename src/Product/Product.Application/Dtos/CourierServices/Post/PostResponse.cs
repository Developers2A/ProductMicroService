namespace Product.Application.Dtos.CourierServices.Post
{
    public class PostResponse<T> where T : class
    {
        public int ResCode { get; set; }
        public string? ResMsg { get; set; }
        public T? Data { get; set; }
    }
}
