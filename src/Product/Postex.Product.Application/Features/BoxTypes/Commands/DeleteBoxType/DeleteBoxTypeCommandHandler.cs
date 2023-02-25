using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxTypes.Commands.DeleteBoxType
{
    public class DeleteBoxTypeCommandHandler : IRequestHandler<DeleteBoxTypeCommand>
    {
        private readonly IWriteRepository<BoxType> _writeRepository;
        private readonly IReadRepository<BoxType> _readRepository;

        public DeleteBoxTypeCommandHandler(IWriteRepository<BoxType> writeRepository,
            IReadRepository<BoxType> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteBoxTypeCommand request, CancellationToken cancellationToken)
        {
            BoxType boxType = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (boxType == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            boxType.IsRemoved = true;
            boxType.RemovedOn = DateTime.Now;

            await _writeRepository.UpdateAsync(boxType);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
