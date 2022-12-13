using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Queries.GetStatus
{
    public class GetPostStatusQueryValidator : AbstractValidator<GetPostStatusQuery>
    {
        public GetPostStatusQueryValidator()
        {
        }
    }
}
