using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierInsurances.Queries
{
    public class GetCourierInsurancesQuery : IRequest<List<CourierInsuranceDto>>
    {
        public class Handler : IRequestHandler<GetCourierInsurancesQuery, List<CourierInsuranceDto>>
        {
            private readonly IReadRepository<CourierInsurance> _courierInsuranceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierInsurance> courierInsuranceRepository, IMapper mapper)
            {
                _courierInsuranceRepository = courierInsuranceRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierInsuranceDto>> Handle(GetCourierInsurancesQuery request, CancellationToken cancellationToken)
            {
                var courierInsurances = await _courierInsuranceRepository.TableNoTracking
                    .OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierInsuranceDto>>(courierInsurances);
            }
        }
    }
}