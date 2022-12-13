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
        public int CourierCityTypeId { get; set; }
        public double Volume { get; set; }

        private class Handler : IRequestHandler<UpdateCourierCityTypePriceCommand>
        {
            private readonly IWriteRepository<CourierCityTypePrice> _parcelCityWriteRepository;
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityReadRepository;

            public Handler(IWriteRepository<CourierCityTypePrice> parcelCityRepository,
                IMediator mediator, IReadRepository<CourierCityTypePrice> parcelCityReadRepository)
            {
                _parcelCityWriteRepository = parcelCityRepository;
                _parcelCityReadRepository = parcelCityReadRepository;
            }

            public async Task<Unit> Handle(UpdateCourierCityTypePriceCommand request, CancellationToken cancellationToken)
            {
                CourierCityTypePrice boxSize = await _parcelCityReadRepository.GetByIdAsync(request.Id, cancellationToken);

                if (boxSize == null)
                    throw new AppException("اطلاعات مورد نظر یافت شد");

                boxSize.Edit(request.BuyPrice, request.SellPrice, request.Volume);
                await _parcelCityWriteRepository.UpdateAsync(boxSize);
                await _parcelCityWriteRepository.SaveChangeAsync();

                return Unit.Value;
            }
        }
        public class EditParcelCityCommandValidator : AbstractValidator<UpdateCourierCityTypePriceCommand>
        {
            public EditParcelCityCommandValidator()
            {
                RuleFor(p => p.CourierCityTypeId)
                 .NotEmpty().WithMessage(" نوع شهر الزامی میباشد");

                RuleFor(p => p.Volume)
                  .NotEmpty().WithMessage("حجم الزامی میباشد");

                RuleFor(p => p.SellPrice)
                  .NotEmpty().WithMessage("قیمت فروش الزامی میباشد");

                RuleFor(p => p.BuyPrice)
                  .NotEmpty().WithMessage("قیمت خرید الزامی میباشد");
            }
        }
    }
}
