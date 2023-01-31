using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommandHandler : IRequestHandler<UpdateCourierCommand>
    {
        private readonly IWriteRepository<Courier> _courierWriteRepository;
        private readonly IReadRepository<Courier> _courierReadRepository;

        public UpdateCourierCommandHandler(
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
            courier.Company = request.Company;
            await _courierWriteRepository.UpdateAsync(courier);
            await _courierWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
