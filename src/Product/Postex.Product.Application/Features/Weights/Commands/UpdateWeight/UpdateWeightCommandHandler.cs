using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Weights.Commands.UpdateWeight
{
    public class UpdateWeightCommandHandler : IRequestHandler<UpdateWeightCommand>
    {
        private readonly IWriteRepository<Weight> _weightWriteRepository;
        private readonly IReadRepository<Weight> _weightReadRepository;

        public UpdateWeightCommandHandler(IWriteRepository<Weight> weightWriteRepository, IReadRepository<Weight> weightReadRepository)
        {
            _weightWriteRepository = weightWriteRepository;
            _weightReadRepository = weightReadRepository;
        }

        public async Task<Unit> Handle(UpdateWeightCommand request, CancellationToken cancellationToken)
        {
            Weight weight = await _weightReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (weight == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            weight.Code = request.Code;
            weight.PostageWeight = request.PostageWeight;
            await _weightWriteRepository.UpdateAsync(weight);
            await _weightWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
