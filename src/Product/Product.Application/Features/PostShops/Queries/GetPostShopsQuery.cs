﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.PostShops;
using Product.Domain.Posts;

namespace Product.Application.Features.PostShops.Queries
{
    public class GetPostShopsQuery : IRequest<List<PostShopDto>>
    {
        public class Handler : IRequestHandler<GetPostShopsQuery, List<PostShopDto>>
        {
            private readonly IReadRepository<PostShop> _postShopRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostShop> courierRepository, IMapper mapper)
            {
                _postShopRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<PostShopDto>> Handle(GetPostShopsQuery request, CancellationToken cancellationToken)
            {
                var postShops = await _postShopRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<PostShopDto>>(postShops);
            }
        }
    }
}