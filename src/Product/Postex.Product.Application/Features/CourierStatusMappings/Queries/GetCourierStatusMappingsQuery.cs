using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingsQuery : IRequest<List<CourierStatusMappingDetailsDto>>
    {
        public CourierCode CourierCode { get; set; }

        public class Handler : IRequestHandler<GetCourierStatusMappingsQuery, List<CourierStatusMappingDetailsDto>>
        {
            private readonly IReadRepository<CourierStatusMapping> _courierStatusMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierStatusMapping> courierStatusMappingReadRepository, IMapper mapper)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierStatusMappingDetailsDto>> Handle(GetCourierStatusMappingsQuery request, CancellationToken cancellationToken)
            {
                var courierStatusMappings = _courierStatusMappingReadRepository.TableNoTracking;
                if (request.CourierCode != CourierCode.All)
                {
                    courierStatusMappings = courierStatusMappings.Where(x => x.Courier.Code == request.CourierCode);
                }

                var courierStatuses = await courierStatusMappings.Include(x => x.Courier).Include(x => x.Status).OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);
                return courierStatuses.Select(x => new CourierStatusMappingDetailsDto()
                {
                    Id = x.Id,
                    CourierCode = (int)x.Courier.Code,
                    CourierName = x.Courier.Name,
                    PostexStatusCode = x.Status.Code,
                    PostexStatusTitle = x.Status.Name,
                    PostexStatusDescription = x.Status.Description,
                    CourierStatusCode = x.Code,
                    CourierStatusTitle = x.Description,
                    CourierStatusDescription = x.Description,
                }).ToList();
            }
        }
    }
}