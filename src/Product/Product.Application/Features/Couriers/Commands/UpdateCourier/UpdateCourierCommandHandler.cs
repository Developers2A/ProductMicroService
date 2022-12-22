using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierServiceCommandHandler : IRequestHandler<UpdateCourierCommand>
    {
        private readonly IWriteRepository<Courier> _courierWriteRepository;
        private readonly IReadRepository<Courier> _courierReadRepository;

        public UpdateCourierServiceCommandHandler(
            IWriteRepository<Courier> courierWriteRepository,
            IReadRepository<Courier> courierReadRepository)
        {
            _courierWriteRepository = courierWriteRepository ?? throw new ArgumentNullException(nameof(courierWriteRepository));
            _courierReadRepository = courierReadRepository;
        }

        public async Task<Unit> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
        {
            Courier courier = await _courierReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            courier.Name = request.Name;

            await _courierWriteRepository.UpdateAsync(courier);
            await _courierWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
