using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Queries
{
    public class GetProvincesCommonQuery : IRequest<List<ProvinceCommonDto>>
    {
        public class Handler : IRequestHandler<GetProvincesCommonQuery, List<ProvinceCommonDto>>
        {
            private readonly IReadRepository<Province> _provinceRepository;

            public Handler(IReadRepository<Province> provinceRepository)
            {
                _provinceRepository = provinceRepository;
            }

            public async Task<List<ProvinceCommonDto>> Handle(GetProvincesCommonQuery request, CancellationToken cancellationToken)
            {
                var provinces = await _provinceRepository.TableNoTracking
                    .Select(c => new ProvinceCommonDto
                    {
                        Code = c.Code,
                        Name = c.Name,
                    })
                    .ToListAsync(cancellationToken);

                return provinces;
            }
        }
    }
}