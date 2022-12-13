namespace Product.Application.Dtos.CourierServices.Post
{
    public class PostEmptyResponse
    {
        public int ResCode { get; set; }
        public string? ResMsg { get; set; }
        public List<PostErrorMessage>? Data { get; set; }
    }
}
