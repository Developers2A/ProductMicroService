using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
{
    public class UpdateValueAddedPriceCommandHandler : IRequestHandler<UpdateValueAddedPriceCommand>
    {
        private readonly IWriteRepository<ValueAddedPrice> _valueAddedPriceWriteRepository;
        private readonly IReadRepository<ValueAddedPrice> _valueAddedPriceReadRepository;

        public UpdateValueAddedPriceCommandHandler(IWriteRepository<ValueAddedPrice> valueAddedPriceWriteRepository,
            IReadRepository<ValueAddedPrice> valueAddedPriceReadRepository)
        {
            _valueAddedPriceWriteRepository = valueAddedPriceWriteRepository;
            _valueAddedPriceReadRepository = valueAddedPriceReadRepository;
        }

        public async Task<Unit> Handle(UpdateValueAddedPriceCommand request, CancellationToken cancellationToken)
        {
            ValueAddedPrice valueAddedPrice = await _valueAddedPriceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (valueAddedPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await UpdateOldAddedValuePrice(valueAddedPrice);
            await CreateNewAddedValuePrice(request);
            return Unit.Value;
        }

        private async Task UpdateOldAddedValuePrice(ValueAddedPrice valueAddedPrice)
        {
            valueAddedPrice.IsActive = false;

            await _valueAddedPriceWriteRepository.UpdateAsync(valueAddedPrice);
            await _valueAddedPriceWriteRepository.SaveChangeAsync();
        }

        private async Task CreateNewAddedValuePrice(UpdateValueAddedPriceCommand request)
        {
            await _valueAddedPriceWriteRepository.AddAsync(new ValueAddedPrice()
            {
                BuyPrice = request.BuyPrice,
                SellPrice = request.SellPrice,
                IsActive = true
            });
            await _valueAddedPriceWriteRepository.SaveChangeAsync();
        }
    }
}
