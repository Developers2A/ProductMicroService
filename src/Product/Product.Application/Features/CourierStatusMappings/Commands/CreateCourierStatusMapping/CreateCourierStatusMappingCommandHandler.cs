using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping
{
    public class CreateCourierStatusMappingCommandHandler : IRequestHandler<CreateCourierStatusMappingCommand>
    {
        private readonly IWriteRepository<CourierStatusMapping> _writeRepository;

        public CreateCourierStatusMappingCommandHandler(IWriteRepository<CourierStatusMapping> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierStatusMappingCommand request, CancellationToken cancellationToken)
        {
            var courierLimit = new CourierStatusMapping()
            {
                CourierApiId = request.CourierApiId
            };

            await _writeRepository.AddAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
