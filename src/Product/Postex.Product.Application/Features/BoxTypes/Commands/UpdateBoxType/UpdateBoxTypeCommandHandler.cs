using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxTypes.Commands.UpdateBoxType
{
    public class UpdateBoxTypeCommandHandler : IRequestHandler<UpdateBoxTypeCommand>
    {
        private readonly IWriteRepository<BoxType> _boxTypeWriteRepository;
        private readonly IReadRepository<BoxType> _boxTypeReadRepository;

        public UpdateBoxTypeCommandHandler(IWriteRepository<BoxType> boxPriceWriteRepository,
            IReadRepository<BoxType> boxPriceReadRepository)
        {
            _boxTypeWriteRepository = boxPriceWriteRepository;
            _boxTypeReadRepository = boxPriceReadRepository;
        }

        public async Task<Unit> Handle(UpdateBoxTypeCommand request, CancellationToken cancellationToken)
        {
            BoxType boxType = await _boxTypeReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            boxType.Name = request.Name;
            boxType.Height = request.Height;
            boxType.Width = request.Width;
            boxType.Length = request.Length;

            await _boxTypeWriteRepository.UpdateAsync(boxType);
            await _boxTypeWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
