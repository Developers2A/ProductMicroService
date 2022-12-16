using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IWriteRepository<Status> _statusWriteRepository;
        private readonly IReadRepository<Status> _stateReadRepository;

        public UpdateStatusCommandHandler(
            IWriteRepository<Status> stateWriteRepository,
            IReadRepository<Status> stateReadRepository)
        {
            _statusWriteRepository = stateWriteRepository;
            _stateReadRepository = stateReadRepository;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            Status state = await _stateReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (state == null)
                throw new AppException("اطلاعات یافت نشد");

            state.Name = request.Name;
            state.Code = request.Code;
            state.Description = request.Description;
            await _statusWriteRepository.UpdateAsync(state);
            await _statusWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
