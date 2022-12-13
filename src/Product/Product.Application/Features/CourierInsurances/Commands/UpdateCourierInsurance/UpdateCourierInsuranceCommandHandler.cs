using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance
{
    public class UpdateCourierInsuranceCommandHandler : IRequestHandler<UpdateCourierInsuranceCommand>
    {
        private readonly IWriteRepository<CourierInsurance> _courierInsuranceWriteRepository;
        private readonly IReadRepository<CourierInsurance> _courierInsuranceReadRepository;

        public UpdateCourierInsuranceCommandHandler(
            IWriteRepository<CourierInsurance> courierInsuranceWriteRepository,
                IReadRepository<CourierInsurance> courierInsuranceReadRepository)
        {
            _courierInsuranceWriteRepository = courierInsuranceWriteRepository;
            _courierInsuranceReadRepository = courierInsuranceReadRepository;
        }

        public async Task<Unit> Handle(UpdateCourierInsuranceCommand request, CancellationToken cancellationToken)
        {
            CourierInsurance courierInsurance = await _courierInsuranceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierInsurance == null)
                throw new AppException("اطلاعات یافت نشد");

            courierInsurance.Name = request.Name;
            await _courierInsuranceWriteRepository.UpdateAsync(courierInsurance);
            await _courierInsuranceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
