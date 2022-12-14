using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZones.Commands.CreateCourierServiceZone
{
    public class CreateCourierServiceZoneCommandHandler : IRequestHandler<CreateCourierServiceZoneCommand>
    {
        private readonly IWriteRepository<CourierServiceZone> _writeRepository;

        public CreateCourierServiceZoneCommandHandler(IWriteRepository<CourierServiceZone> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierServiceZoneCommand request, CancellationToken cancellationToken)
        {
            var courierServiceZone = new CourierServiceZone()
            {
                StateFromId = request.StateFromId,
                StateToId = request.StateToId,
                CityFromId = request.CityFromId,
                CityToId = request.CityToId,
                ZoneId = request.ZoneId,
                CourierId = request.CourierId,
                CourierServiceId = request.CourierServiceId
            };

            await _writeRepository.AddAsync(courierServiceZone);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
