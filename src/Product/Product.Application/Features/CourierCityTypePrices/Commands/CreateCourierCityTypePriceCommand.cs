using FluentValidation;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Application.Contracts;
using Product.Domain.Couriers;
using Product.Domain.Enums;

namespace Product.Application.Features.CourierCityTypePrices.Commands
{
    public class CreateCourierCityTypePriceCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode CityType { get; set; }
        public double Volume { get; set; }

        private class Handler : IRequestHandler<CreateCourierCityTypePriceCommand>
        {
            private readonly IWriteRepository<CourierCityTypePrice> _parcelCityWriteRepository;

            public Handler(IWriteRepository<CourierCityTypePrice> parcelCityWriteRepository)
            {
                _parcelCityWriteRepository = parcelCityWriteRepository;
            }

            public async Task<Unit> Handle(CreateCourierCityTypePriceCommand request, CancellationToken cancellationToken)
            {
                var boxSize = new CourierCityTypePrice(request.BuyPrice, request.SellPrice, request.CourierId, request.CityType, request.Volume);
                await _parcelCityWriteRepository.AddAsync(boxSize);
                await _parcelCityWriteRepository.SaveChangeAsync();
                return Unit.Value;
            }
        }

        public class CreateParcelCityCommandValidator : AbstractValidator<CreateCourierCityTypePriceCommand>
        {
            public CreateParcelCityCommandValidator()
            {
                RuleFor(p => p.CourierId)
                    .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شناسه کوریر الزامی میباشد");

                RuleFor(p => p.CityType)
                  .NotEmpty().NotNull().WithMessage(" نوع شهر الزامی میباشد");

                RuleFor(p => p.Volume)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage("حجم الزامی میباشد");

                RuleFor(p => p.SellPrice)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage("قیمت فروش الزامی میباشد");

                RuleFor(p => p.BuyPrice)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage("قیمت خرید الزامی میباشد");
            }
        }
    }
}
