using AutoMapper;
using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostexCods.Commands.CreatePostexCod
{
    public class CreatePostexCodCommandHandler : IRequestHandler<CreatePostexCodCommand>
    {
        private readonly IWriteRepository<PostexCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreatePostexCodCommandHandler(IWriteRepository<PostexCod> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePostexCodCommand request, CancellationToken cancellationToken)
        {
            var postexCod = _mapper.Map<PostexCod>(request);

            await _writeRepository.AddAsync(postexCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
