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
            private readonly IReadRepository<Province> _stateRepository;

            public Handler(IReadRepository<Province> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<ProvinceDto> Handle(GetProvinceByIdQuery request, CancellationToken cancellationToken)
            {
                var state = await _stateRepository.Table
                    .Select(c => new ProvinceDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = c.Code,
                        EnglishName = c.EnglishName
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return state;
            }
        }
    }
}