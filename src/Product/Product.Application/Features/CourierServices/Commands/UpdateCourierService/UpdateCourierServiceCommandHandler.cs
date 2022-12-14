using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Commands.UpdateCourierService
{
    public class UpdateCourierServiceCommandHandler : IRequestHandler<UpdateCourierServiceCommand>
    {
        private readonly IWriteRepository<CourierService> _courierServiceWriteRepository;
        private readonly IReadRepository<CourierService> _courierServiceReadRepository;

        public UpdateCourierServiceCommandHandler(IWriteRepository<CourierService> courierServiceWriteRepository,
            IReadRepository<CourierService> courierServiceReadRepository)
        {
            _courierServiceWriteRepository = courierServiceWriteRepository ?? throw new ArgumentNullException(nameof(courierServiceWriteRepository));
            _courierServiceReadRepository = courierServiceReadRepository;
        }

        public async Task<Unit> Handle(UpdateCourierServiceCommand request, CancellationToken cancellationToken)
        {
            CourierService courierService = await _courierServiceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierService == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            courierService.Name = request.Name;
            courierService.Days = request.Days;

            await _courierServiceWriteRepository.UpdateAsync(courierService);
            await _courierServiceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
