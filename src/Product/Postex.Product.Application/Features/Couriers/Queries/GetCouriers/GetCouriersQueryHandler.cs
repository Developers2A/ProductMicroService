using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Couriers.Queries.GetCouriers
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