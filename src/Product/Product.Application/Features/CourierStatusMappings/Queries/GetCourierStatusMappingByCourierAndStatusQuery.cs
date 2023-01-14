using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingByCourierAndStatusQuery : IRequest<CourierStatusMappingDto>
    {
        public string CourierStatus { get; set; }
        public CourierCode Courier { get; set; }

        public class Handler : IRequestHandler<GetCourierStatusMappingByCourierAndStatusQuery, CourierStatusMappingDto>
        {
            private readonly IReadRepository<CourierStatusMapping> _courierStatusMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierStatusMapping> courierStatusMappingReadRepository, IMapper mapper)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
                _mapper = mapper;
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
                return _mapper.Map<CourierStatusMappingDto>(courierStatusMapping);
            }
        }
    }
}