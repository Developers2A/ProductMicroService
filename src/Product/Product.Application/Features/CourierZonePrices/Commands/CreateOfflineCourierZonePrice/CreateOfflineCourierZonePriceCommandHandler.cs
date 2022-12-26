using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Application.Features.CourierZonePrices.Commands.CreateChaparCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Commands.CreatePostCourierZonePrice;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateOfflineCourierZonePriceCommandHandler : IRequestHandler<CreateOfflineCourierZonePriceCommand>
    {
        private readonly IMediator _mediator;

        public CreateOfflineCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateOfflineCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateChaparCourierZonePriceCommand());
            await _mediator.Send(new CreatePostCourierZonePriceCommand());
            return Unit.Value;
        }
    }
}
