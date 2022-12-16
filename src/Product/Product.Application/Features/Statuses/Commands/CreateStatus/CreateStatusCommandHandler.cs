using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand>
    {
        private readonly IWriteRepository<Status> _statusWriteRepository;

        public CreateStatusCommandHandler(IWriteRepository<Status> statusWriteRepository)
        {
            _statusWriteRepository = statusWriteRepository;
        }

        public async Task<Unit> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = new Status()
            {
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                Order = request.Order,
                Type = request.Type
            };

            await _statusWriteRepository.AddAsync(status);
            await _statusWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
