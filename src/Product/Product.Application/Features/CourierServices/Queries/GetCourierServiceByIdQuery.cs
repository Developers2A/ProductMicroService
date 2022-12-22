using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Queries
{
    public class GetCourierServiceByIdQuery : IRequest<CourierServiceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierServiceByIdQuery, CourierServiceDto>
        {
            private readonly IReadRepository<CourierService> _courierServiceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierService> courierServiceRepository, IMapper mapper)
            {
                _courierServiceRepository = courierServiceRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CourierServiceDto> Handle(GetCourierServiceByIdQuery request, CancellationToken cancellationToken)
            {
                var courier = await _courierServiceRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierServiceDto>(courier);
            }
        }
    }
}