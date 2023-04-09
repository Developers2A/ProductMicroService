using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Posts;
using Postex.Product.Domain.Posts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CityZipCodes.Queries
{
    public class GetCityZipCodesQuery : IRequest<List<CityZipCodeDto>>
    {
        public int? CityCode { get; set; }

        public class Handler : IRequestHandler<GetCityZipCodesQuery, List<CityZipCodeDto>>
        {
            private readonly IReadRepository<CityZipCode> _cityZipCodeRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CityZipCode> cityZipCodeRepository, IMapper mapper)
            {
                _cityZipCodeRepository = cityZipCodeRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<CityZipCodeDto>> Handle(GetCityZipCodesQuery request, CancellationToken cancellationToken)
            {
                var cityZipCodes = _cityZipCodeRepository.TableNoTracking;
                if (request.CityCode.HasValue && request.CityCode > 0)
                {
                    cityZipCodes = cityZipCodes.Where(x => x.IsValid && x.City.Code == request.CityCode);
                }
                var cityZipCodeList = await cityZipCodes.OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<CityZipCodeDto>>(cityZipCodeList);
            }
        }
    }
}