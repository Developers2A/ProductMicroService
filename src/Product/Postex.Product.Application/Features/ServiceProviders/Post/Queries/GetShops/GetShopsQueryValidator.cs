using FluentValidation;
using System.Globalization;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetShops
{
    public class GetShopsQueryValidator : AbstractValidator<GetShopsQuery>
    {
        public GetShopsQueryValidator()
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("fa-IR");

            RuleFor(p => p.Page)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("شماره صفحه باید بزرگتر از صفر باشد");

            RuleFor(p => p.PageSize)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage("سایز صفحه باید بزرگتر از صفر باشد");
        }
    }
}
