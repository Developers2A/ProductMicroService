using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Commands.CreateCourierService
{
    public class CreateCourierServiceCommandHandler : IRequestHandler<CreateCourierServiceCommand>
    {
        private readonly IWriteRepository<CourierService> _courierServiceWriteRepository;

        public CreateCourierServiceCommandHandler(IWriteRepository<CourierService> courierServiceWriteRepository)
        {
            _courierServiceWriteRepository = courierServiceWriteRepository ?? throw new ArgumentNullException(nameof(courierServiceWriteRepository));
        }

        public async Task<Unit> Handle(CreateCourierServiceCommand request, CancellationToken cancellationToken)
        {
            var courierService = new CourierService()
            {
                Name = request.Name,
                Days = request.Days,
                CourierId = request.CourierId
            };

            await _courierServiceWriteRepository.AddAsync(courierService);
            await _courierServiceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
