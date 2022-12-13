using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Queries
{
    public class GetCourierByIdQuery : IRequest<CourierDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierByIdQuery, CourierDto>
        {
            private readonly IReadRepository<Courier> _courierRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<Courier> courierRepository, IMapper mapper)
            {
                _courierRepository = courierRepository;
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CourierDto> Handle(GetCourierByIdQuery request, CancellationToken cancellationToken)
            {
                var courier = await _courierRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<CourierDto>(courier);
            }
        }
    }
}