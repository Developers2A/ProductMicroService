using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.BoxPrices.Commands.DeleteBoxPrice
{
    public class DeleteBoxPriceCommandHandler : IRequestHandler<DeleteBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxSizePrice> _writeRepository;
        private readonly IReadRepository<BoxSizePrice> _readRepository;

        public DeleteBoxPriceCommandHandler(IWriteRepository<BoxSizePrice> writeRepository,
            IReadRepository<BoxSizePrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteBoxPriceCommand request, CancellationToken cancellationToken)
        {
            BoxSizePrice boxPrice = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(boxPrice);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
