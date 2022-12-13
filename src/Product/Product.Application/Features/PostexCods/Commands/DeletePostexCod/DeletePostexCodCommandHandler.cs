using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.PostexCods.Commands.DeletePostexCod
{
    public class DeletePostexCodCommandHandler : IRequestHandler<DeletePostexCodCommand>
    {
        private readonly IWriteRepository<PostexCod> _writeRepository;
        private readonly IReadRepository<PostexCod> _readRepository;

        public DeletePostexCodCommandHandler(IWriteRepository<PostexCod> writeRepository,
            IReadRepository<PostexCod> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeletePostexCodCommand request, CancellationToken cancellationToken)
        {
            PostexCod postexCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (postexCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(postexCod);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
