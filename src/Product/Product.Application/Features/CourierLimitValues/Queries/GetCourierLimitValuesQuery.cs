using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierLimitValues.Queries
{
    public class GetCourierLimitValuesQuery : IRequest<List<CourierLimitValueDto>>
    {
        public class Handler : IRequestHandler<GetCourierLimitValuesQuery, List<CourierLimitValueDto>>
        {
            private readonly IReadRepository<CourierLimitValue> _courierLimitValueRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierLimitValue> courierLimitValueRepository, IMapper mapper)
            {
                _courierLimitValueRepository = courierLimitValueRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierLimitValueDto>> Handle(GetCourierLimitValuesQuery request, CancellationToken cancellationToken)
            {
                var courierLimitValues = await _courierLimitValueRepository.TableNoTracking
                    .OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierLimitValueDto>>(courierLimitValues);
            }
        }
    }
}