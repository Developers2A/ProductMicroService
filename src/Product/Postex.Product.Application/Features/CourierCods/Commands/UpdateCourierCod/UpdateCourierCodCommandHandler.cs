using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCods.Commands.UpdateCourierCod
{
    public class UpdateCourierCodCommandHandler : IRequestHandler<UpdateCourierCodCommand>
    {
        private readonly IWriteRepository<CourierCod> _writeRepository;
        private readonly IReadRepository<CourierCod> _readRepository;

        public UpdateCourierCodCommandHandler(IWriteRepository<CourierCod> writeRepository,
            IReadRepository<CourierCod> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdateCourierCodCommand request, CancellationToken cancellationToken)
        {
            CourierCod courierCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(courierCod);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
