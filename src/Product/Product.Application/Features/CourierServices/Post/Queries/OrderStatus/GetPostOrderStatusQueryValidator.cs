using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Queries.OrderStatus
{
    public class GetPostOrderStatusQueryValidator : AbstractValidator<GetPostOrderStatusQuery>
    {
        public GetPostOrderStatusQueryValidator()
        {
        }
    }
}
