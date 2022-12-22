using FluentValidation;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Application.Contracts;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCityTypePrices.Commands
{
    public class UpdateCourierCityTypePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Volume { get; set; }

        private class Handler : IRequestHandler<UpdateCourierCityTypePriceCommand>
        {
            private readonly IWriteRepository<CourierCityTypePrice> _courierCityTypePriceWriteRepository;
            private readonly IReadRepository<CourierCityTypePrice> _courierCityTypePriceReadRepository;

            public Handler(IWriteRepository<CourierCityTypePrice> parcelCityRepository,
                IMediator mediator, IReadRepository<CourierCityTypePrice> parcelCityReadRepository)
            {
                _courierCityTypePriceWriteRepository = parcelCityRepository;
                _courierCityTypePriceReadRepository = parcelCityReadRepository;
            }

            public async Task<Unit> Handle(UpdateCourierCityTypePriceCommand request, CancellationToken cancellationToken)
            {
                CourierCityTypePrice courierCityTypePrice = await _courierCityTypePriceReadRepository.GetByIdAsync(request.Id, cancellationToken);

                if (courierCityTypePrice == null)
                    throw new AppException("اطلاعات مورد نظر یافت شد");

                courierCityTypePrice.Edit(request.BuyPrice, request.SellPrice, request.Volume);
                await _courierCityTypePriceWriteRepository.UpdateAsync(courierCityTypePrice);
                await _courierCityTypePriceWriteRepository.SaveChangeAsync();

                return Unit.Value;
            }
        }
        public class EditParcelCityCommandValidator : AbstractValidator<UpdateCourierCityTypePriceCommand>
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
