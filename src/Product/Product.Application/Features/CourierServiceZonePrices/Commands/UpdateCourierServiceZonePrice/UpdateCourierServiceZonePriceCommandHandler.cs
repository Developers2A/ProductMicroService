using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.UpdateCourierServiceZonePrice
{
    public class UpdateCourierServiceZonePriceCommandHandler : IRequestHandler<UpdateCourierServiceZonePriceCommand>
    {
        private readonly IWriteRepository<CourierServiceZonePrice> _writeRepository;
        private readonly IReadRepository<CourierServiceZonePrice> _readRepository;

        public UpdateCourierServiceZonePriceCommandHandler(IWriteRepository<CourierServiceZonePrice> writeRepository,
            IReadRepository<CourierServiceZonePrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierServiceZonePriceCommand request, CancellationToken cancellationToken)
        {
            CourierServiceZonePrice courierZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(courierZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
