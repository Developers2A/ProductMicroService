using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue
{
    public class UpdateCourierLimitValueCommandHandler : IRequestHandler<UpdateCourierLimitValueCommand>
    {
        private readonly IWriteRepository<CourierLimitValue> _writeRepository;
        private readonly IReadRepository<CourierLimitValue> _readRepository;

        public UpdateCourierLimitValueCommandHandler(
            IWriteRepository<CourierLimitValue> writeRepository,
            IReadRepository<CourierLimitValue> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierLimitValueCommand request, CancellationToken cancellationToken)
        {
            CourierLimitValue courierLimitValue = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimitValue == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            courierLimitValue.UpperLimit = request.UpperLimit;
            courierLimitValue.LowerLimit = request.LowerLimit;

            await _writeRepository.UpdateAsync(courierLimitValue);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
