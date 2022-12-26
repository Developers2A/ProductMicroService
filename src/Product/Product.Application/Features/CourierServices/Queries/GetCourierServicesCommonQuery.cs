using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Queries
{
    public class GetCourierServicesCommonQuery : IRequest<List<CourierServiceCommonDto>>
    {
        public class Handler : IRequestHandler<GetCourierServicesCommonQuery, List<CourierServiceCommonDto>>
        {
            private readonly IReadRepository<CourierService> _courierServiceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierService> courierServiceRepository, IMapper mapper)
            {
                _courierServiceRepository = courierServiceRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<CourierServiceCommonDto>> Handle(GetCourierServicesCommonQuery request, CancellationToken cancellationToken)
            {
                var couriers = await _courierServiceRepository.TableNoTracking.Include(x => x.Courier)
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return couriers.Select(x => new CourierServiceCommonDto()
                {
                    CourierCode = (int)x.Courier.Code,
                    CourierServiceCode = (int)x.Code,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}