using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IWriteRepository<Status> _statusWriteRepository;
        private readonly IReadRepository<Status> _statusReadRepository;

        public UpdateStatusCommandHandler(
            IWriteRepository<Status> statusWriteRepository,
            IReadRepository<Status> statusReadRepository)
        {
            _statusWriteRepository = statusWriteRepository;
            _statusReadRepository = statusReadRepository;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            Status status = await _statusReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (status == null)
                throw new AppException("اطلاعات یافت نشد");

            status.Name = request.Name;
            status.Code = request.Code;
            status.Description = request.Description;
            await _statusWriteRepository.UpdateAsync(status);
            await _statusWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
