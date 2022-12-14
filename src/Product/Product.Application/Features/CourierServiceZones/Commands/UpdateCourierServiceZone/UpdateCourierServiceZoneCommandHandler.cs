using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZones.Commands.UpdateCourierServiceZone
{
    public class UpdateCourierServiceZoneCommandHandler : IRequestHandler<UpdateCourierServiceZoneCommand>
    {
        private readonly IWriteRepository<CourierServiceZone> _writeRepository;
        private readonly IReadRepository<CourierServiceZone> _readRepository;

        public UpdateCourierServiceZoneCommandHandler(IWriteRepository<CourierServiceZone> writeRepository,
            IReadRepository<CourierServiceZone> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierServiceZoneCommand request, CancellationToken cancellationToken)
        {
            CourierServiceZone courierServiceZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierServiceZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(courierServiceZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
