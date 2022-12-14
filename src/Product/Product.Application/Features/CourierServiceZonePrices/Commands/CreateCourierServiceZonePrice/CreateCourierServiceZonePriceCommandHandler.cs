using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.CreateCourierServiceZonePrice
{
    public class CreateCourierServiceZonePriceCommandHandler : IRequestHandler<CreateCourierServiceZonePricePriceCommand>
    {
        private readonly IWriteRepository<CourierServiceZonePrice> _writeRepository;

        public CreateCourierServiceZonePriceCommandHandler(IWriteRepository<CourierServiceZonePrice> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierServiceZonePricePriceCommand request, CancellationToken cancellationToken)
        {
            var courierLimit = new CourierServiceZonePrice()
            {
                SellPrice = request.SellPrice
            };

            await _writeRepository.AddAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
