using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Posts
{
    public class PostToken : BaseEntity<int>
    {
        public string Token { get; set; }
    }
}
