using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommandHandler : IRequestHandler<UpdateBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxPrice> _boxPriceWriteRepository;
        private readonly IReadRepository<BoxPrice> _boxPriceReadRepository;

        public UpdateBoxPriceCommandHandler(IWriteRepository<BoxPrice> boxPriceWriteRepository,
            IReadRepository<BoxPrice> boxPriceReadRepository)
        {
            _boxPriceWriteRepository = boxPriceWriteRepository;
            _boxPriceReadRepository = boxPriceReadRepository;
        }

        public async Task<Unit> Handle(UpdateBoxPriceCommand request, CancellationToken cancellationToken)
        {
            BoxPrice boxPrice = await _boxPriceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            boxPrice.Name = request.Name;
            boxPrice.SellPrice = request.SellPrice;

            await _boxPriceWriteRepository.UpdateAsync(boxPrice);
            await _boxPriceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
