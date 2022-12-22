using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZones.Commands.UpdateCourierZone
{
    public class UpdateCourierZoneCommandHandler : IRequestHandler<UpdateCourierZoneCommand>
    {
        private readonly IWriteRepository<CourierZone> _writeRepository;
        private readonly IReadRepository<CourierZone> _readRepository;

        public UpdateCourierZoneCommandHandler(IWriteRepository<CourierZone> writeRepository,
            IReadRepository<CourierZone> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierZoneCommand request, CancellationToken cancellationToken)
        {
            CourierZone courierZone = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            courierZone.Name = request.Name;
            //courierZone.Code = request.Code;
            await _writeRepository.UpdateAsync(courierZone);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
