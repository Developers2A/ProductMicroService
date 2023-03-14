using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Queries
{
    public class GetProvinceByIdQuery : IRequest<ProvinceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetProvinceByIdQuery, ProvinceDto>
        {
            private readonly IReadRepository<Province> _provinceRepository;

            public Handler(IReadRepository<Province> provinceRepository)
            {
                _provinceRepository = provinceRepository;
            }

            public async Task<ProvinceDto> Handle(GetProvinceByIdQuery request, CancellationToken cancellationToken)
            {
                var province = await _provinceRepository.Table
                    .Select(c => new ProvinceDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = c.Code,
                        EnglishName = c.EnglishName
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return province;
            }
        }
    }
}