using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Posts;

namespace Product.Application.Features.PostShops.Commands.CreatePostShop
{
    public class CreatePostShopCommandHandler : IRequestHandler<CreatePostShopCommand>
    {
        private readonly IWriteRepository<PostShop> _postShopWriteRepository;
        private readonly IMapper _mapper;

        public CreatePostShopCommandHandler(IWriteRepository<PostShop> postShopWriteRepository, IMapper mapper)
        {
            _postShopWriteRepository = postShopWriteRepository ?? throw new ArgumentNullException(nameof(postShopWriteRepository));
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePostShopCommand request, CancellationToken cancellationToken)
        {
            var postShop = _mapper.Map<PostShop>(request);

            await _postShopWriteRepository.AddAsync(postShop);
            await _postShopWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
