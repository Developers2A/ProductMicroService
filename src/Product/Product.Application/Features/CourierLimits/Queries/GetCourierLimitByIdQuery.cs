using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierLimits.Queries
{
    public class GetCourierLimitByIdQuery : IRequest<CourierLimitDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCourierLimitByIdQuery, CourierLimitDto>
        {
            private readonly IReadRepository<CourierLimit> _courierLimitReadRepository;

            public Handler(IReadRepository<CourierLimit> courierLimitReadRepository)
            {
                _courierLimitReadRepository = courierLimitReadRepository;
            }

            public async Task<CourierLimitDto> Handle(GetCourierLimitByIdQuery request, CancellationToken cancellationToken)
            {
                var courierLimit = await _courierLimitReadRepository.TableNoTracking
                    .Select(c => new CourierLimitDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CreatedOn = c.CreatedOn
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return courierLimit;
            }
        }
    }
}