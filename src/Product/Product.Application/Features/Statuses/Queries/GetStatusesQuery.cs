using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Couriers;

namespace Product.Application.Features.Statuses.Queries
{
    public class GetStatusesQuery : IRequest<List<StatusDto>>
    {
        public class Handler : IRequestHandler<GetStatusesQuery, List<StatusDto>>
        {
            private readonly IReadRepository<Status> _stateRepository;

            public Handler(IReadRepository<Status> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<List<StatusDto>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
            {
                var statuses = await _stateRepository.Table
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