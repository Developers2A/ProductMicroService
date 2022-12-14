using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZones.Commands.DeleteCourierServiceZone
{
    public class DeleteCourierServiceZoneCommandHandler : IRequestHandler<DeleteCourierServiceZoneCommand>
    {
        private readonly IWriteRepository<CourierServiceZone> _writeRepository;
        private readonly IReadRepository<CourierServiceZone> _readRepository;

        public DeleteCourierServiceZoneCommandHandler(IWriteRepository<CourierServiceZone> writeRepository,
            IReadRepository<CourierServiceZone> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierServiceZoneCommand request, CancellationToken cancellationToken)
        {
            CourierServiceZone courierServiceZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierServiceZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierServiceZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
