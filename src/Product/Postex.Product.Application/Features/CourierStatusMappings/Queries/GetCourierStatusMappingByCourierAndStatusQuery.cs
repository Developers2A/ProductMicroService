using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingByCourierAndStatusQuery : IRequest<CourierStatusMappingDto>
    {
        public string CourierStatus { get; set; }
        public SharedKernel.Common.Enums.CourierCode Courier { get; set; }

        public class Handler : IRequestHandler<GetCourierStatusMappingByCourierAndStatusQuery, CourierStatusMappingDto>
        {
            private readonly IReadRepository<CourierStatusMapping> _courierStatusMappingReadRepository;

            public Handler(IReadRepository<CourierStatusMapping> courierStatusMappingReadRepository)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
            }

            public async Task<CourierStatusMappingDto> Handle(GetCourierStatusMappingByCourierAndStatusQuery request, CancellationToken cancellationToken)
            {
                var courierStatusMappingQuery = _courierStatusMappingReadRepository.TableNoTracking
                    .Where(x => x.Courier.Code == request.Courier);
                if (request.Courier == SharedKernel.Common.Enums.CourierCode.Mahex || request.Courier == SharedKernel.Common.Enums.CourierCode.Speed)
                {
                    courierStatusMappingQuery = courierStatusMappingQuery.Where(x => x.Description == request.CourierStatus);
                }
                else
                {
                    courierStatusMappingQuery = courierStatusMappingQuery.Where(x => x.Code == request.CourierStatus);
                }
                var courierStatusMapping = await courierStatusMappingQuery.Include(x => x.Status).FirstOrDefaultAsync();

                if (courierStatusMapping != null)
                {
                    return new CourierStatusMappingDto()
                    {
                        Id = courierStatusMapping.Id,
                        StatusId = courierStatusMapping.StatusId,
                        StatusName = courierStatusMapping.Status.Description,
                        StatusCode = courierStatusMapping.Status.Code,
                        CourierId = courierStatusMapping.CourierId,
                        CourierStatusName = courierStatusMapping.Description,
                        CourierStatusCode = courierStatusMapping.Code,
                    };
                }
                return null;
            }
        }
    }
}