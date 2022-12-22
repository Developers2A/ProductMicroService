using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommandHandler : IRequestHandler<DeleteCourierCommand>
    {
        private readonly IWriteRepository<Courier> _writeRepository;
        private readonly IReadRepository<Courier> _readRepository;

        public DeleteCourierCommandHandler(IWriteRepository<Courier> writeRepository,
            IReadRepository<Courier> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierCommand request, CancellationToken cancellationToken)
        {
            Courier courier = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courier);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
