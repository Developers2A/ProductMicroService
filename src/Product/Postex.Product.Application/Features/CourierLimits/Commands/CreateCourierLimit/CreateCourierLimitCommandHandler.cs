﻿using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit
{
    public class CreateCourierLimitCommandHandler : IRequestHandler<CreateCourierLimitCommand>
    {
        private readonly IWriteRepository<CourierLimit> _writeRepository;

        public CreateCourierLimitCommandHandler(IWriteRepository<CourierLimit> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateCourierLimitCommand request, CancellationToken cancellationToken)
        {
            var courierLimit = new CourierLimit()
            {
                Name = request.Name,
            };

            await _writeRepository.AddAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
