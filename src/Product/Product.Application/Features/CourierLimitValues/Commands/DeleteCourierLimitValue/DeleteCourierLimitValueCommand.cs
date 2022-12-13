using FluentValidation;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Application.Contracts;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierLimitValues.Commands.DeleteCourierLimitValue
{
    public class DeleteCourierLimitValueCommand : ITransactionRequest
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<DeleteCourierLimitValueCommand>
        {
            private readonly IWriteRepository<CourierLimitValue> _writeRepository;
            private readonly IReadRepository<CourierLimitValue> _readRepository;

            public Handler(IWriteRepository<CourierLimitValue> writeRepository,
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

        public class DeleteCourierLimitValueCommandValidator : AbstractValidator<DeleteCourierLimitValueCommand>
        {
            public DeleteCourierLimitValueCommandValidator()
            {
                RuleFor(p => p.Id)
                    .NotEmpty().WithMessage(" شناسه الزامی میباشد");
            }
        }
    }
}
