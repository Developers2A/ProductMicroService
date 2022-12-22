using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Commands.DeleteCourierZonePrice
{
    public class DeleteCourierZonePriceCommandHandler : IRequestHandler<DeleteCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _writeRepository;
        private readonly IReadRepository<CourierZonePrice> _readRepository;

        public DeleteCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository,
            IReadRepository<CourierZonePrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            CourierZonePrice courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
