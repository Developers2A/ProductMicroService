using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Queries.GetCourierServiceById
{
    public class GetCourierServiceByIdQueryHandler : IRequestHandler<GetCourierServiceByIdQuery, CourierServiceDto>
    {
        private readonly IReadRepository<CourierService> _courierServiceReadRepository;

        public GetCourierServiceByIdQueryHandler(IReadRepository<CourierService> courierServiceRepository)
        {
            _courierServiceReadRepository = courierServiceRepository;
        }

        public async Task<CourierServiceDto> Handle(GetCourierServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var courierService = await _courierServiceReadRepository.TableNoTracking
                .Select(c => new CourierServiceDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return courierService;
        }
    }
}
