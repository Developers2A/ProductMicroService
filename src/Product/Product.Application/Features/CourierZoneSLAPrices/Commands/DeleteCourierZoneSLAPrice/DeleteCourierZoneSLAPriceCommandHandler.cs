using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.DeleteCourierZoneSLAPrice
{
    public class DeleteCourierZoneSLAPriceCommandHandler : IRequestHandler<DeleteCourierZoneSLAPriceCommand>
    {
        private readonly IWriteRepository<CourierZoneSLAPrice> _writeRepository;
        private readonly IReadRepository<CourierZoneSLAPrice> _readRepository;

        public DeleteCourierZoneSLAPriceCommandHandler(IWriteRepository<CourierZoneSLAPrice> writeRepository,
            IReadRepository<CourierZoneSLAPrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierZoneSLAPriceCommand request, CancellationToken cancellationToken)
        {
            CourierZoneSLAPrice courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
