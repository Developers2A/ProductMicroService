using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit
{
    public class UpdateCourierLimitCommandHandler : IRequestHandler<UpdateCourierLimitCommand>
    {
        private readonly IWriteRepository<CourierLimit> _writeRepository;
        private readonly IReadRepository<CourierLimit> _readRepository;

        public UpdateCourierLimitCommandHandler(
            IWriteRepository<CourierLimit> writeRepository,
            IReadRepository<CourierLimit> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierLimitCommand request, CancellationToken cancellationToken)
        {
            CourierLimit courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            courierLimit.Name = request.Name;
            await _writeRepository.UpdateAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
