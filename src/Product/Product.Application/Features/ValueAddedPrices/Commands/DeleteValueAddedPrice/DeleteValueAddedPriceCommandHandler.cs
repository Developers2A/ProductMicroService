using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.ValueAddedPrices.Commands.DeleteValueAddedPrice
{
    public class DeleteValueAddedPriceCommandHandler : IRequestHandler<DeleteValueAddedPriceCommand>
    {
        private readonly IWriteRepository<ValueAddedPrice> _writeRepository;
        private readonly IReadRepository<ValueAddedPrice> _readRepository;

        public DeleteValueAddedPriceCommandHandler(IWriteRepository<ValueAddedPrice> writeRepository,
            IReadRepository<ValueAddedPrice> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteValueAddedPriceCommand request, CancellationToken cancellationToken)
        {
            ValueAddedPrice valueAddedPrice = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (valueAddedPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(valueAddedPrice);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
