using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.PostexInsurances.Queries
{
    public class GetPostexInsurancesQuery : IRequest<List<PostexInsuranceDto>>
    {
        public class Handler : IRequestHandler<GetPostexInsurancesQuery, List<PostexInsuranceDto>>
        {
            private readonly IReadRepository<PostexInsurance> _courierInsuranceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostexInsurance> courierInsuranceRepository, IMapper mapper)
            {
                _courierInsuranceRepository = courierInsuranceRepository;
                _mapper = mapper;
            }

            public async Task<List<PostexInsuranceDto>> Handle(GetPostexInsurancesQuery request, CancellationToken cancellationToken)
            {
                var courierInsurances = await _courierInsuranceRepository.TableNoTracking
                    .OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
                return _mapper.Map<List<PostexInsuranceDto>>(courierInsurances);
            }
        }
    }
}