using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Queries.GetCourierServices
{
    public class GetCourierServicesQueryHandler : IRequestHandler<GetCourierServicesQuery, List<CourierServiceDto>>
    {
        private readonly IReadRepository<CourierService> _courierServiceReadRepository;

        public GetCourierServicesQueryHandler(IReadRepository<CourierService> courierServiceReadRepository)
        {
            _courierServiceReadRepository = courierServiceReadRepository;
        }

        public async Task<List<CourierServiceDto>> Handle(GetCourierServicesQuery request, CancellationToken cancellationToken)
        {
            var courierServices = await _courierServiceReadRepository.TableNoTracking
                .Select(c => new CourierServiceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CourierId = c.CourierId,
                    Days = c.Days
                })
                .OrderByDescending(c => c.Id)
                .ToListAsync(cancellationToken);

            return courierServices;
        }
    }

}