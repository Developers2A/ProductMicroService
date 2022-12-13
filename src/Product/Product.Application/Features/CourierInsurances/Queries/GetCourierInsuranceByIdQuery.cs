using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierInsurances.Queries
{
    public class GetCourierInsuranceByIdQuery : IRequest<CourierInsuranceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierInsuranceByIdQuery, CourierInsuranceDto>
        {
            private readonly IReadRepository<CourierInsurance> _courierInsuranceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierInsurance> courierInsuranceRepository, IMapper mapper)
            {
                _courierInsuranceRepository = courierInsuranceRepository;
                _mapper = mapper;
            }

            public async Task<CourierInsuranceDto> Handle(GetCourierInsuranceByIdQuery request, CancellationToken cancellationToken)
            {
                var courierInsurance = await _courierInsuranceRepository.TableNoTracking
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierInsuranceDto>(courierInsurance);
            }
        }
    }
}