using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostShops.Commands.UpdatePostShop
{
    public class UpdatePostShopCommandHandler : IRequestHandler<UpdatePostShopCommand>
    {
        private readonly IWriteRepository<PostShop> _postShopWriteRepository;
        private readonly IReadRepository<PostShop> _postShopReadRepository;
        private readonly IMapper _mapper;

        public UpdatePostShopCommandHandler(IWriteRepository<PostShop> couierWriteRepository, IReadRepository<PostShop> courierReadRepository, IMapper mapper)
        {
            _postShopWriteRepository = couierWriteRepository ?? throw new ArgumentNullException(nameof(couierWriteRepository));
            _postShopReadRepository = courierReadRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostShopCommand request, CancellationToken cancellationToken)
        {
            PostShop postShop = await _postShopReadRepository.Table.FirstOrDefaultAsync(x => x.ShopId == request.ShopID);

            if (postShop == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            var newPostShop = _mapper.Map(request, postShop);
            await _postShopWriteRepository.UpdateAsync(newPostShop);
            await _postShopWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
