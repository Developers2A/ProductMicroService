using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Queries
{
    public class GetCourierServicesQuery : IRequest<List<CourierServiceDto>>
    {
        public class Handler : IRequestHandler<GetCourierServicesQuery, List<CourierServiceDto>>
        {
            private readonly IReadRepository<CourierService> _courierServiceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierService> courierRepository, IMapper mapper)
            {
                _courierServiceRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<CourierServiceDto>> Handle(GetCourierServicesQuery request, CancellationToken cancellationToken)
            {
                var couriers = await _courierServiceRepository.TableNoTracking
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierServiceDto>>(couriers);
            }
        }
    }
}