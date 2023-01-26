using MediatR;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZones.Commands.DeleteCourierZone
{
    public class DeleteCourierZoneCommandHandler : IRequestHandler<DeleteCourierZoneCommand>
    {
        private readonly IWriteRepository<CourierZone> _writeRepository;
        private readonly IReadRepository<CourierZone> _readRepository;

        public DeleteCourierZoneCommandHandler(IWriteRepository<CourierZone> writeRepository,
            IReadRepository<CourierZone> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierZoneCommand request, CancellationToken cancellationToken)
        {
            CourierZone courierZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
