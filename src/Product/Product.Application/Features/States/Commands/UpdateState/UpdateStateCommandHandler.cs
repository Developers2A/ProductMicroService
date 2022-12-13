using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Locations;

namespace Product.Application.Features.States.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand>
    {
        private readonly IWriteRepository<State> _stateWriteRepository;
        private readonly IReadRepository<State> _stateReadRepository;

        public UpdateStateCommandHandler(
            IWriteRepository<State> stateWriteRepository,
            IReadRepository<State> stateReadRepository)
        {
            _stateWriteRepository = stateWriteRepository;
            _stateReadRepository = stateReadRepository;
        }

        public async Task<Unit> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            State state = await _stateReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (state == null)
                throw new AppException("اطلاعات یافت نشد");

            state.Name = request.Name;
            state.Code = request.Code;
            state.EnglishName = request.EnglishName;
            await _stateWriteRepository.UpdateAsync(state);
            await _stateWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
