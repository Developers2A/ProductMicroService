using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAs.Commands.DeleteCourierZoneSLA
{
    public class DeleteCourierZoneSLACommandHandler : IRequestHandler<DeleteCourierZoneSLACommand>
    {
        private readonly IWriteRepository<CourierZoneSLA> _writeRepository;
        private readonly IReadRepository<CourierZoneSLA> _readRepository;

        public DeleteCourierZoneSLACommandHandler(IWriteRepository<CourierZoneSLA> writeRepository,
            IReadRepository<CourierZoneSLA> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierZoneSLACommand request, CancellationToken cancellationToken)
        {
            CourierZoneSLA courierZoneSLA = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZoneSLA == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierZoneSLA);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
