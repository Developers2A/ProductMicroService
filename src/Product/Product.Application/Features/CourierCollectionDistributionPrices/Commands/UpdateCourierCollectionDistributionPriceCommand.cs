using FluentValidation;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Application.Contracts;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Commands
{
    public class UpdateCourierCollectionDistributionPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Volume { get; set; }

        private class Handler : IRequestHandler<UpdateCourierCollectionDistributionPriceCommand>
        {
            private readonly IWriteRepository<CourierZoneCollectionDistributionPrice> _courierCityTypePriceWriteRepository;
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierCityTypePriceReadRepository;

            public Handler(IWriteRepository<CourierZoneCollectionDistributionPrice> parcelCityRepository,
                IMediator mediator, IReadRepository<CourierZoneCollectionDistributionPrice> parcelCityReadRepository)
            {
                _courierCityTypePriceWriteRepository = parcelCityRepository;
                _courierCityTypePriceReadRepository = parcelCityReadRepository;
            }

            public async Task<Unit> Handle(UpdateCourierCollectionDistributionPriceCommand request, CancellationToken cancellationToken)
            {
                CourierZoneCollectionDistributionPrice courierCityTypePrice = await _courierCityTypePriceReadRepository.GetByIdAsync(request.Id, cancellationToken);

                if (courierCityTypePrice == null)
                    throw new AppException("اطلاعات مورد نظر یافت شد");

                courierCityTypePrice.Edit(request.BuyPrice, request.SellPrice, request.Volume);
                await _courierCityTypePriceWriteRepository.UpdateAsync(courierCityTypePrice);
                await _courierCityTypePriceWriteRepository.SaveChangeAsync();

                return Unit.Value;
            }
        }
        public class EditParcelCityCommandValidator : AbstractValidator<UpdateCourierCollectionDistributionPriceCommand>
        {
            public EditParcelCityCommandValidator()
            {
                RuleFor(p => p.Id)
                    .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

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
