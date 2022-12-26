using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Queries.GetCouriers
{
    public class GetCouriersQueryHandler : IRequestHandler<GetCouriersQuery, List<CourierDto>>
    {
        private readonly IReadRepository<Courier> _courierReadRepository;

        public GetCouriersQueryHandler(IReadRepository<Courier> courierReadRepository)
        {
            _courierReadRepository = courierReadRepository;
        }

        public async Task<List<CourierDto>> Handle(GetCouriersQuery request, CancellationToken cancellationToken)
        {
            var couriers = await _courierReadRepository.TableNoTracking
                .Select(c => new CourierDto
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderByDescending(c => c.Id)
                .ToListAsync(cancellationToken);

            return couriers;
        }
    }

}