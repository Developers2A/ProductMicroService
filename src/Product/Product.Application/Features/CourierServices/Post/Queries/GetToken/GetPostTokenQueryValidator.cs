using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Queries.GetToken
{
    public class GetPostTokenQueryValidator : AbstractValidator<GetPostTokenQuery>
    {
        public GetPostTokenQueryValidator()
        {
        }
    }
}
