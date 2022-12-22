using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandHandler : IRequestHandler<CreateCourierCommand>
    {
        private readonly IWriteRepository<Courier> _courierWriteRepository;

        public CreateCourierCommandHandler(IWriteRepository<Courier> courierServiceWriteRepository)
        {
            _courierWriteRepository = courierServiceWriteRepository ?? throw new ArgumentNullException(nameof(courierServiceWriteRepository));
        }

        public async Task<Unit> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
        {
            var courier = new Courier()
            {
                Name = request.Name,
            };

            await _courierWriteRepository.AddAsync(courier);
            await _courierWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
