using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierServices.Queries
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