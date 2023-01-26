using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Zones.Queries
{
    public class GetZoneByIdQuery : IRequest<ZoneDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetZoneByIdQuery, ZoneDto>
        {
            private readonly IReadRepository<Zone> _zoneRepository;

            public Handler(IReadRepository<Zone> zoneRepository)
            {
                _zoneRepository = zoneRepository;
            }

            public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
            {
                var zone = await _zoneRepository.Table
                    .Select(c => new ZoneDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return zone;
            }
        }
    }
}