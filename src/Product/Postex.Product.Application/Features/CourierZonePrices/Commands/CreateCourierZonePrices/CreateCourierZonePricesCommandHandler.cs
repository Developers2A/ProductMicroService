using MediatR;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices
{
    public class CreateCourierZonePriceCommandHandler : IRequestHandler<CreateCourierZonePricesCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;

        public CreateCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository)
        {
            _courierZonePriceWriteRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierZonePricesCommand request, CancellationToken cancellationToken)
        {
            var courierZonePrices = request.CourierZonePrices.Select(x => new CourierZonePrice()
            {
                FromCourierZoneId = x.FromCourierZoneId,
                ToCourierZoneId = x.ToCourierZoneId,
                CourierServiceId = x.CourierServiceId,
                Weight = x.Weight,
                SellPrice = x.SellPrice,
                BuyPrice = x.BuyPrice,
                SameState = x.SameState
            });

            await _courierZonePriceWriteRepository.AddRangeAsync(courierZonePrices);
            await _courierZonePriceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
