using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Queries
{
    public class GetCourierZoneSLAPriceByIdQuery : IRequest<CourierZoneSLAPriceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneSLAPriceByIdQuery, CourierZoneSLAPriceDto>
        {
            private readonly IReadRepository<CourierZoneSLAPriceDto> _courierZoneSLAPriceReadRepository;

            public Handler(IReadRepository<CourierZoneSLAPriceDto> courierZoneSLAPriceReadRepository)
            {
                _courierZoneSLAPriceReadRepository = courierZoneSLAPriceReadRepository;
            }

            public async Task<CourierZoneSLAPriceDto> Handle(GetCourierZoneSLAPriceByIdQuery request, CancellationToken cancellationToken)
            {
                var courierZone = await _courierZoneSLAPriceReadRepository.Table
                    .Select(c => new CourierZoneSLAPriceDto
                    {
                        Id = c.Id,
                        CreatedOn = c.CreatedOn
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierZone;
            }
        }
    }
}