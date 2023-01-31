using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Zones.Queries
{
    public class GetZonesQuery : IRequest<List<ZoneDto>>
    {
        public class Handler : IRequestHandler<GetZonesQuery, List<ZoneDto>>
        {
            private readonly IReadRepository<Zone> _zoneRepository;

            public Handler(IReadRepository<Zone> zoneRepository)
            {
                _zoneRepository = zoneRepository;
            }

            public async Task<List<ZoneDto>> Handle(GetZonesQuery request, CancellationToken cancellationToken)
            {
                var zones = await _zoneRepository.TableNoTracking
                    .Select(c => new ZoneDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return zones;
            }
        }
    }
}