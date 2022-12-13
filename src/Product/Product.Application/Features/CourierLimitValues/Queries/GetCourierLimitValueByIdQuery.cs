using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierLimitValues.Queries
{
    public class GetCourierLimitValueByIdQuery : IRequest<CourierLimitValueDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierLimitValueByIdQuery, CourierLimitValueDto>
        {
            private readonly IReadRepository<CourierLimitValue> _courierLimitValueRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierLimitValue> courierLimitValueRepository, IMapper mapper)
            {
                _courierLimitValueRepository = courierLimitValueRepository;
                _mapper = mapper;
            }

            public async Task<CourierLimitValueDto> Handle(GetCourierLimitValueByIdQuery request, CancellationToken cancellationToken)
            {
                var courierLimitValue = await _courierLimitValueRepository.TableNoTracking
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierLimitValueDto>(courierLimitValue);
            }
        }
    }
}