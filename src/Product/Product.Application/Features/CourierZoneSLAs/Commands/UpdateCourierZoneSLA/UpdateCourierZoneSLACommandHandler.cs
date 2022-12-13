using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAs.Commands.UpdateCourierZoneSLA
{
    public class UpdateCourierZoneSLACommandHandler : IRequestHandler<UpdateCourierZoneSLACommand>
    {
        private readonly IWriteRepository<CourierZoneSLA> _writeRepository;
        private readonly IReadRepository<CourierZoneSLA> _readRepository;

        public UpdateCourierZoneSLACommandHandler(IWriteRepository<CourierZoneSLA> writeRepository,
            IReadRepository<CourierZoneSLA> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierZoneSLACommand request, CancellationToken cancellationToken)
        {
            CourierZoneSLA courierZoneSLA = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierZoneSLA == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(courierZoneSLA);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
