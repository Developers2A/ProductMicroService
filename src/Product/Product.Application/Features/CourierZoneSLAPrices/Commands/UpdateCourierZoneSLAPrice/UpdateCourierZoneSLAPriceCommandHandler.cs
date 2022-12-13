using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.UpdateCourierZoneSLAPrice
{
    public class UpdateCourierZoneSLAPriceCommandHandler : IRequestHandler<UpdateCourierZoneSLAPriceCommand>
    {
        private readonly IWriteRepository<CourierZoneSLAPrice> _writeRepository;
        private readonly IReadRepository<CourierZoneSLAPrice> _readRepository;

        public UpdateCourierZoneSLAPriceCommandHandler(IWriteRepository<CourierZoneSLAPrice> writeRepository,
            IReadRepository<CourierZoneSLAPrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierZoneSLAPriceCommand request, CancellationToken cancellationToken)
        {
            CourierZoneSLAPrice courierZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(courierZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
