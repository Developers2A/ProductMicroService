﻿using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZones.Commands.CreateCourierZone
{
    public class CreateCourierZoneCommandHandler : IRequestHandler<CreateCourierZoneCommand>
    {
        private readonly IWriteRepository<CourierZone> _writeRepository;

        public CreateCourierZoneCommandHandler(IWriteRepository<CourierZone> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierZoneCommand request, CancellationToken cancellationToken)
        {
            var courierServiceZone = new CourierZone()
            {
                Name = request.Name,
                //Code = request.Code,
                CourierId = request.CourierId,
            };

            await _writeRepository.AddAsync(courierServiceZone);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
