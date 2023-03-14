using MediatR;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice
{
    public class CreateCourierZonePriceCommandHandler : IRequestHandler<CreateCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;
        private readonly IReadRepository<CourierZonePriceTemplate> _courierZonePriceTemplateRepository;
        private readonly IMediator _mediator;

        public CreateCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator)
        {
            _courierZonePriceWriteRepository = writeRepository;
            _courierZonePriceTemplateRepository = courierZonePriceTemplateRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            var courierZonePrice = new CourierZonePrice()
            {
                FromCourierZoneId = request.FromCourierZoneId,
                ToCourierZoneId = request.ToCourierZoneId,
                CourierServiceId = request.CourierServiceId,
                Weight = request.Weight,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                SameProvince = request.SameProvince
            };

            await _courierZonePriceWriteRepository.AddAsync(courierZonePrice);
            await _courierZonePriceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
