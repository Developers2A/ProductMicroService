using MediatR;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.UpdateCourierZonePrice
{
    public class UpdateCourierZonePriceCommandHandler : IRequestHandler<UpdateCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _writeRepository;
        private readonly IReadRepository<CourierZonePrice> _readRepository;

        public UpdateCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository,
            IReadRepository<CourierZonePrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            CourierZonePrice courierZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");
            courierZone.BuyPrice = request.BuyPrice;

            await _writeRepository.UpdateAsync(courierZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
