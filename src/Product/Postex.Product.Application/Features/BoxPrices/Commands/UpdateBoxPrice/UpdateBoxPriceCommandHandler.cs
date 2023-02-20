using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommandHandler : IRequestHandler<UpdateBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxSizePrice> _boxPriceWriteRepository;
        private readonly IReadRepository<BoxSizePrice> _boxPriceReadRepository;

        public UpdateBoxPriceCommandHandler(IWriteRepository<BoxSizePrice> boxPriceWriteRepository,
            IReadRepository<BoxSizePrice> boxPriceReadRepository)
        {
            _boxPriceWriteRepository = boxPriceWriteRepository;
            _boxPriceReadRepository = boxPriceReadRepository;
        }

        public async Task<Unit> Handle(UpdateBoxPriceCommand request, CancellationToken cancellationToken)
        {
            BoxSizePrice boxPrice = await _boxPriceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            boxPrice.BuyPrice = request.BuyPrice;
            boxPrice.SellPrice = request.SellPrice;

            await _boxPriceWriteRepository.UpdateAsync(boxPrice);
            await _boxPriceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
