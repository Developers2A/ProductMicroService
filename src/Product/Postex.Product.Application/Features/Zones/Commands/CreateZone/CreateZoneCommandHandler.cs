﻿using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Zones.Commands.CreateZone
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand>
    {
        private readonly IWriteRepository<Zone> _writeRepository;

        public CreateZoneCommandHandler(IWriteRepository<Zone> zoneWriteRepository)
        {
            _writeRepository = zoneWriteRepository;
        }

        public async Task<Unit> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = new Zone()
            {
                Name = request.Name,
            };

            await _writeRepository.AddAsync(zone);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
