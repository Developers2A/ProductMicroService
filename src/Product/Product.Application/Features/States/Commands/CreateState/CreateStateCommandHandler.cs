using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Locations;

namespace Product.Application.Features.States.Commands.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand>
    {
        private readonly IWriteRepository<State> _stateWriteRepository;

        public CreateStateCommandHandler(IWriteRepository<State> stateWriteRepository)
        {
            _stateWriteRepository = stateWriteRepository;
        }

        public async Task<Unit> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var state = new State()
            {
                Name = request.Name,
                Code = request.Code,
                EnglishName = request.EnglishName
            };

            await _stateWriteRepository.AddAsync(state);
            await _stateWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
