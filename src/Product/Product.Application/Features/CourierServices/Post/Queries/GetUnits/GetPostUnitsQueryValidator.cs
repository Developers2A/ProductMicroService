﻿using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Queries.GetUnits
{
    public class GetPostUnitsQueryValidator : AbstractValidator<GetPostUnitsQuery>
    {
        public GetPostUnitsQueryValidator()
        {
            RuleFor(p => p.ProvinceId)
                .NotNull().NotEmpty().WithMessage(" شناسه استان الزامی میباشد");
        }
    }
}
