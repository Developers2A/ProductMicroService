using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Statuses.Queries
{
    public class GetStatusByIdQuery : IRequest<StatusDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetStatusByIdQuery, StatusDto>
        {
            private readonly IReadRepository<Status> _statusRepository;

            public Handler(IReadRepository<Status> statusRepository)
            {
                _statusRepository = statusRepository;
            }

            public async Task<StatusDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
            {
                var status = await _statusRepository.Table
                    .Select(c => new StatusDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = c.Code,
                        Description = c.Description,
                        Order = c.Order,
                        Type = c.Type
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return status;
            }
        }
    }
}