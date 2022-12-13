using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommandHandler : IRequestHandler<UpdateBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxPrice> _slaWriteRepository;
        private readonly IReadRepository<BoxPrice> _slaReadRepository;

        public UpdateBoxPriceCommandHandler(IWriteRepository<BoxPrice> slaWriteRepository,
            IReadRepository<BoxPrice> slaReadRepository)
        {
            _slaWriteRepository = slaWriteRepository;
            _slaReadRepository = slaReadRepository;
        }

        public async Task<Unit> Handle(UpdateBoxPriceCommand request, CancellationToken cancellationToken)
        {
            BoxPrice boxPrice = await _slaReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxPrice == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            boxPrice.Name = request.Name;
            boxPrice.SellPrice = request.SellPrice;

            await _slaWriteRepository.UpdateAsync(boxPrice);
            await _slaWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
