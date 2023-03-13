using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Queries
{
    public class GetProvincesQuery : IRequest<List<ProvinceDto>>
    {
        public class Handler : IRequestHandler<GetProvincesQuery, List<ProvinceDto>>
        {
            private readonly IReadRepository<Province> _stateRepository;

            public Handler(IReadRepository<Province> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<List<ProvinceDto>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
            {
                var states = await _stateRepository.Table
                    .Select(c => new ProvinceDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        EnglishName = c.EnglishName,
                        Code = c.Code
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return states;
            }
        }
    }
}