using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Commands.DeleteCourierService
{
    public class DeleteCourierServiceCommandHandler : IRequestHandler<DeleteCourierServiceCommand>
    {
        private readonly IWriteRepository<CourierService> _writeRepository;
        private readonly IReadRepository<CourierService> _readRepository;

        public DeleteCourierServiceCommandHandler(IWriteRepository<CourierService> writeRepository,
            IReadRepository<CourierService> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierServiceCommand request, CancellationToken cancellationToken)
        {
            CourierService courierService = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierService == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierService);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
