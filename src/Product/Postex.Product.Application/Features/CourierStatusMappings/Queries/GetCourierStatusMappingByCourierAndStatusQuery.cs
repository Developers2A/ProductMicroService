using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingByCourierAndStatusQuery : IRequest<CourierStatusMappingDto>
    {
        public string CourierStatus { get; set; }
        public CourierCode Courier { get; set; }

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
                if (request.Courier == CourierCode.Mahex || request.Courier == CourierCode.Speed)
                {
                    courierStatusMappingQuery = courierStatusMappingQuery.Where(x => x.Description == request.CourierStatus);
                }
                else
                {
                    courierStatusMappingQuery = courierStatusMappingQuery.Where(x => x.Code == request.CourierStatus);
                }
                var courierStatusMapping = await courierStatusMappingQuery.Include(x => x.Status).FirstOrDefaultAsync();
                return new CourierStatusMappingDto()
                {
                    Id = courierStatusMapping.Id,
                    StatusId = courierStatusMapping.StatusId,
                    Code = courierStatusMapping.Code,
                    Name = courierStatusMapping.Status.Description,
                    CourierId = courierStatusMapping.CourierId,
                    Description = courierStatusMapping.Description,
                };
            }
        }
    }
}