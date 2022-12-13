using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Queries
{
    public class GetCourierZoneSLAPricesQuery : IRequest<List<CourierZoneSLAPriceDto>>
    {
        public class Handler : IRequestHandler<GetCourierZoneSLAPricesQuery, List<CourierZoneSLAPriceDto>>
        {
            private readonly IReadRepository<CourierZoneSLAPrice> _courierZoneSLAPriceReadRepository;

            public Handler(IReadRepository<CourierZoneSLAPrice> courierZoneSLAPriceReadRepository)
            {
                _courierZoneSLAPriceReadRepository = courierZoneSLAPriceReadRepository;
            }

            public async Task<List<CourierZoneSLAPriceDto>> Handle(GetCourierZoneSLAPricesQuery request, CancellationToken cancellationToken)
            {
                var courierZoneSLAPrices = await _courierZoneSLAPriceReadRepository.TableNoTracking
                    .Select(c => new CourierZoneSLAPriceDto
                    {
                        Id = c.Id,
                        CreatedOn = c.CreatedOn
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierZoneSLAPrices;
            }
        }
    }
}