using FluentValidation;
using MediatR;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Contracts;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Commands
{
    public class CreateCourierCollectionDistributionPriceCommand : ITransactionRequest
    {
        public int CourierZoneId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public CityTypeCode CityType { get; set; }
        public double Volume { get; set; }

        private class Handler : IRequestHandler<CreateCourierCollectionDistributionPriceCommand>
        {
            private readonly IWriteRepository<CourierZoneCollectionDistributionPrice> _parcelCityWriteRepository;

            public Handler(IWriteRepository<CourierZoneCollectionDistributionPrice> parcelCityWriteRepository)
            {
                _parcelCityWriteRepository = parcelCityWriteRepository;
            }

            public async Task<Unit> Handle(CreateCourierCollectionDistributionPriceCommand request, CancellationToken cancellationToken)
            {
                var courierZoneCollectionDistributionPrice = new CourierZoneCollectionDistributionPrice(request.BuyPrice, request.SellPrice, request.CourierZoneId, request.Volume);
                await _parcelCityWriteRepository.AddAsync(courierZoneCollectionDistributionPrice);
                await _parcelCityWriteRepository.SaveChangeAsync();
                return Unit.Value;
            }
        }

        public class CreateParcelCityCommandValidator : AbstractValidator<CreateCourierCollectionDistributionPriceCommand>
        {
            public CreateParcelCityCommandValidator()
            {
                RuleFor(p => p.CourierZoneId)
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
