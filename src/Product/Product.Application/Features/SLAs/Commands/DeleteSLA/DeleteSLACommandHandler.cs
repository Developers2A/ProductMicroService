using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.SLAs.Commands.DeleteSLA
{
    public class DeleteSLACommandHandler : IRequestHandler<DeleteSLACommand>
    {
        private readonly IWriteRepository<SLA> _writeRepository;
        private readonly IReadRepository<SLA> _readRepository;

        public DeleteSLACommandHandler(IWriteRepository<SLA> writeRepository,
            IReadRepository<SLA> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteSLACommand request, CancellationToken cancellationToken)
        {
            SLA sla = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sla == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(sla);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
