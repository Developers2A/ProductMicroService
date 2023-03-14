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
            private readonly IReadRepository<Province> _provinceRepository;

            public Handler(IReadRepository<Province> provinceRepository)
            {
                _provinceRepository = provinceRepository;
            }

            public async Task<List<ProvinceDto>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
            {
                var provinces = await _provinceRepository.Table
                    .Select(c => new ProvinceDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        EnglishName = c.EnglishName,
                        Code = c.Code
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return provinces;
            }
        }
    }
}