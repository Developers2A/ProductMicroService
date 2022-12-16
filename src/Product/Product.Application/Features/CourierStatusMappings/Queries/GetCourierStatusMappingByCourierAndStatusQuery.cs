using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;
using Product.Domain.Enums;

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
                var courierStatusMappingQuery = _courierStatusMappingReadRepository.TableNoTracking.Include(x => x.Status)
                    .Include(x => x.CourierApi).ThenInclude(x => x.Courier)
                    .Where(x => x.CourierApi.Courier.Code == request.Courier && x.Code == request.CourierStatus);
                var courierStatusMapping = await courierStatusMappingQuery.FirstOrDefaultAsync();
                return _mapper.Map<CourierStatusMappingDto>(courierStatusMapping);
            }
        }
    }
}