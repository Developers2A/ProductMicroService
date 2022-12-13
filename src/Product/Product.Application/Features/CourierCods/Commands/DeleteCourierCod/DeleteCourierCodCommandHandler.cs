using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCods.Commands.DeleteCourierCod
{
    public class DeleteCourierCodCommandHandler : IRequestHandler<DeleteCourierCodCommand>
    {
        private readonly IWriteRepository<CourierCod> _writeRepository;
        private readonly IReadRepository<CourierCod> _readRepository;

        public DeleteCourierCodCommandHandler(IWriteRepository<CourierCod> writeRepository,
            IReadRepository<CourierCod> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierCodCommand request, CancellationToken cancellationToken)
        {
            CourierCod courierCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierCod);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
