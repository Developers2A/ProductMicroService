using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierStatusMappings.Commands.DeleteCourierStatusMapping
{
    public class DeleteCourierStatusMappingCommandHandler : IRequestHandler<DeleteCourierStatusMappingCommand>
    {
        private readonly IWriteRepository<CourierStatusMapping> _writeRepository;
        private readonly IReadRepository<CourierStatusMapping> _readRepository;

        public DeleteCourierStatusMappingCommandHandler(IWriteRepository<CourierStatusMapping> writeRepository,
            IReadRepository<CourierStatusMapping> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierStatusMappingCommand request, CancellationToken cancellationToken)
        {
            CourierStatusMapping courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
