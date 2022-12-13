using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.SLAs.Commands.UpdateSLA
{
    public class UpdateSLACommandHandler : IRequestHandler<UpdateSLACommand>
    {
        private readonly IWriteRepository<SLA> _slaWriteRepository;
        private readonly IReadRepository<SLA> _slaReadRepository;

        public UpdateSLACommandHandler(IWriteRepository<SLA> slaWriteRepository,
            IReadRepository<SLA> slaReadRepository)
        {
            _slaWriteRepository = slaWriteRepository ?? throw new ArgumentNullException(nameof(slaWriteRepository));
            _slaReadRepository = slaReadRepository;
        }

        public async Task<Unit> Handle(UpdateSLACommand request, CancellationToken cancellationToken)
        {
            SLA sla = await _slaReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sla == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            sla.Name = request.Name;
            sla.Days = request.Days;

            await _slaWriteRepository.UpdateAsync(sla);
            await _slaWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
