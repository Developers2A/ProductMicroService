using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierServices.Queries
{
    public class GetCourierServicesCommonQuery : IRequest<List<CourierServiceCommonDto>>
    {
        public int? CourierServiceCode { get; set; }

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
                var courierServices = _courierServiceRepository.TableNoTracking;
                if (request.CourierServiceCode.HasValue && request.CourierServiceCode > 0)
                {
                    courierServices = courierServices.Where(x => x.Code == (CourierServiceCode)request.CourierServiceCode);
                }
                var courierServiceList = await courierServices.Include(x => x.Courier)
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierServiceList.Select(x => new CourierServiceCommonDto()
                {
                    CourierCode = (int)x.Courier.Code,
                    CourierName = x.Courier.Name,
                    CourierServiceCode = (int)x.Code,
                    CourierServiceName = x.Name,
                    Days = x.Days
                }).ToList();
            }
        }
    }
}