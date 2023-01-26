using Postex.SharedKernel.Domain;

namespace Product.Domain.Posts
{
    public class PostToken : BaseEntity<int>
    {
        public string Token { get; set; }
    }
}
