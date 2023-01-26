using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping
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
            var courierStatusMapping = new CourierStatusMapping()
            {
                Version = request.Version,
                StatusId = request.StatusId,
                Description = request.Description,
                Code = request.Code
            };

            await _writeRepository.AddAsync(courierStatusMapping);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
