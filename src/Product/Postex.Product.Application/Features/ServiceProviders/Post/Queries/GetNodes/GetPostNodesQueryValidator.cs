using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetNodes
{
    public class GetPostNodesQueryValidator : AbstractValidator<GetPostNodesQuery>
    {
        public GetPostNodesQueryValidator()
        {
            RuleFor(p => p.CityId)
                .NotNull().NotEmpty().WithMessage(" شناسه شهر الزامی میباشد");
        }
    }
}
