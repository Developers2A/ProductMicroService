using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.SLAs.Commands.CreateSLA
{
    public class CreateSLACommandHandler : IRequestHandler<CreateSLACommand>
    {
        private readonly IWriteRepository<SLA> _slaWriteRepository;

        public CreateSLACommandHandler(IWriteRepository<SLA> slaWriteRepository)
        {
            _slaWriteRepository = slaWriteRepository ?? throw new ArgumentNullException(nameof(slaWriteRepository));
        }

        public async Task<Unit> Handle(CreateSLACommand request, CancellationToken cancellationToken)
        {
            var sla = new SLA()
            {
                Name = request.Name,
                Days = request.Days,
                CourierId = request.CourierId
            };

            await _slaWriteRepository.AddAsync(sla);
            await _slaWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
