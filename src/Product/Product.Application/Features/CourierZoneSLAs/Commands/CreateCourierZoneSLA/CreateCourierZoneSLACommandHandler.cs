using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAs.Commands.CreateCourierZoneSLA
{
    public class CreateCourierZoneSLACommandHandler : IRequestHandler<CreateCourierZoneSLACommand>
    {
        private readonly IWriteRepository<CourierZoneSLA> _writeRepository;

        public CreateCourierZoneSLACommandHandler(IWriteRepository<CourierZoneSLA> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierZoneSLACommand request, CancellationToken cancellationToken)
        {
            var courierZoneSLA = new CourierZoneSLA()
            {
                StateFromId = request.StateFromId,
                StateToId = request.StateToId,
                CityFromId = request.CityFromId,
                CityToId = request.CityToId,
                ZoneId = request.ZoneId,
                CourierId = request.CourierId,
                SLAId = request.SLAId
            };

            await _writeRepository.AddAsync(courierZoneSLA);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
