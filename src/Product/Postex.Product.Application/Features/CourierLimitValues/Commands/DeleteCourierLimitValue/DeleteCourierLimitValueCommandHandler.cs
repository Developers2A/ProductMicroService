﻿using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimitValues.Commands.DeleteCourierLimitValue
{
    public class DeleteCourierLimitValueCommandHandler : IRequestHandler<DeleteCourierLimitValueCommand>
    {
        private readonly IWriteRepository<CourierLimitValue> _writeRepository;
        private readonly IReadRepository<CourierLimitValue> _readRepository;

        public DeleteCourierLimitValueCommandHandler(
            IWriteRepository<CourierLimitValue> writeRepository,
            IMediator mediator, IReadRepository<CourierLimitValue> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(DeleteCourierLimitValueCommand request, CancellationToken cancellationToken)
        {
            CourierLimitValue courierLimit = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierLimit == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.DeleteAsync(courierLimit);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
