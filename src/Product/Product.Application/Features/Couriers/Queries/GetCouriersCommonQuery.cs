using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Queries
{
    public class GetCouriersCommonQuery : IRequest<List<CourierCommonDto>>
    {
        public class Handler : IRequestHandler<GetCouriersCommonQuery, List<CourierCommonDto>>
        {
            private readonly IReadRepository<Courier> _courierRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<Courier> courierRepository, IMapper mapper)
            {
                _courierRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<CourierCommonDto>> Handle(GetCouriersCommonQuery request, CancellationToken cancellationToken)
            {
                var couriers = await _courierRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierCommonDto>>(couriers);
            }
        }
    }
}