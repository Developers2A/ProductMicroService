using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Locations;

namespace Product.Application.Features.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand>
    {
        private readonly IWriteRepository<Zone> _zoneWriteRepository;
        private readonly IReadRepository<Zone> _zoneReadRepository;

        public UpdateZoneCommandHandler(IWriteRepository<Zone> zoneWriteRepository, IReadRepository<Zone> zoneReadRepository)
        {
            _zoneWriteRepository = zoneWriteRepository;
            _zoneReadRepository = zoneReadRepository;
        }

        public async Task<Unit> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            Zone zone = await _zoneReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (zone == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            zone.Name = request.Name;
            await _zoneWriteRepository.UpdateAsync(zone);
            await _zoneWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
