using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Weights.Commands.CreateWeight
{
    public class CreateWeightCommandHandler : IRequestHandler<CreateWeightCommand>
    {
        private readonly IWriteRepository<Weight> _weightWriteRepository;

        public CreateWeightCommandHandler(IWriteRepository<Weight> weightWriteRepository)
        {
            _weightWriteRepository = weightWriteRepository;
        }

        public async Task<Unit> Handle(CreateWeightCommand request, CancellationToken cancellationToken)
        {
            var weight = new Weight()
            {
                Code = request.Code,
                PostageWeight = request.PostageWeight
            };

            await _weightWriteRepository.AddAsync(weight);
            await _weightWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
