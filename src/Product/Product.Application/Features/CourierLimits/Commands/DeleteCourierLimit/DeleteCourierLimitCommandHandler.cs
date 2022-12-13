using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierLimits.Commands.DeleteCourierLimit
{
    public class DeleteCourierLimitCommandHandler : IRequestHandler<DeleteCourierLimitCommand>
    {
        private readonly IWriteRepository<CourierLimit> _writeRepository;
        private readonly IReadRepository<CourierLimit> _readRepository;

        public DeleteCourierLimitCommandHandler(IWriteRepository<CourierLimit> writeRepository,
            IMediator mediator, IReadRepository<CourierLimit> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierLimitCommand request, CancellationToken cancellationToken)
        {
            CourierLimit courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
