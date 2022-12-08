namespace Product.Application.Dtos.Post
{
    public class PostEmptyResponse
    {
        public int ResCode { get; set; }
        public string? ResMsg { get; set; }
        public List<PostErrorMessage>? Data { get; set; }
    }
}
