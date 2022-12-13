using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.CreateCourierZoneSLAPrice
{
    public class CreateCourierZoneSLAPriceCommandHandler : IRequestHandler<CreateCourierZoneSLAPriceCommand>
    {
        private readonly IWriteRepository<CourierZoneSLAPrice> _writeRepository;

        public CreateCourierZoneSLAPriceCommandHandler(IWriteRepository<CourierZoneSLAPrice> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierZoneSLAPriceCommand request, CancellationToken cancellationToken)
        {
            var courierLimit = new CourierZoneSLAPrice()
            {
                SellPrice = request.SellPrice
            };

            await _writeRepository.AddAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
