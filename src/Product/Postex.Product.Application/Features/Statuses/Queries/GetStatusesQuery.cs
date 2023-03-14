using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Statuses.Queries
{
    public class GetStatusesQuery : IRequest<List<StatusDto>>
    {
        public class Handler : IRequestHandler<GetStatusesQuery, List<StatusDto>>
        {
            private readonly IReadRepository<Status> _statusRepository;

            public Handler(IReadRepository<Status> statusRepository)
            {
                _statusRepository = statusRepository;
            }

            public async Task<List<StatusDto>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
            {
                var statuses = await _statusRepository.Table
                    .Select(c => new StatusDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        Code = c.Code,
                        Type = c.Type,
                        Order = c.Order,
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return statuses;
            }
        }
    }
}