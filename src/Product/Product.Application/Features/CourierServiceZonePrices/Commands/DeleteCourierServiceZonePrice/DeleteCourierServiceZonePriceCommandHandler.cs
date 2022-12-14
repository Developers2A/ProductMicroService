using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.DeleteCourierServiceZonePrice
{
    public class DeleteCourierServiceZonePriceCommandHandler : IRequestHandler<DeleteCourierServiceZonePriceCommand>
    {
        private readonly IWriteRepository<CourierServiceZonePrice> _writeRepository;
        private readonly IReadRepository<CourierServiceZonePrice> _readRepository;

        public DeleteCourierServiceZonePriceCommandHandler(IWriteRepository<CourierServiceZonePrice> writeRepository,
            IReadRepository<CourierServiceZonePrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierServiceZonePriceCommand request, CancellationToken cancellationToken)
        {
            CourierServiceZonePrice courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
