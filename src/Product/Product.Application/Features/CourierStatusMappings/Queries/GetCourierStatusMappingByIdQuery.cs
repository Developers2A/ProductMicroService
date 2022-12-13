using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierStatusMappings.Queries
{
    public class GetCourierStatusMappingByIdQuery : IRequest<CourierStatusMappingDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierStatusMappingByIdQuery, CourierStatusMappingDto>
        {
            private readonly IReadRepository<CourierStatusMapping> _courierStatusMappingReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierStatusMapping> courierStatusMappingReadRepository, IMapper mapper)
            {
                _courierStatusMappingReadRepository = courierStatusMappingReadRepository;
                _mapper = mapper;
            }

            public async Task<CourierStatusMappingDto> Handle(GetCourierStatusMappingByIdQuery request, CancellationToken cancellationToken)
            {
                var courierStatusMapping = await _courierStatusMappingReadRepository.GetByIdAsync(request.Id, cancellationToken);
                return _mapper.Map<CourierStatusMappingDto>(courierStatusMapping);
            }
        }
    }
}