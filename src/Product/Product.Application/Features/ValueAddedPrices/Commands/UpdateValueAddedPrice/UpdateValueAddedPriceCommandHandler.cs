using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
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

            valueAddedPrice.Name = request.Name;
            valueAddedPrice.SellPrice = request.SellPrice;

            await _valueAddedPriceWriteRepository.UpdateAsync(valueAddedPrice);
            await _valueAddedPriceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
