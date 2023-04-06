using MediatR;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateChaparCourierZonePrice;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreatePostCourierZonePrice;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateOfflineCourierZonePriceCommandHandler : IRequestHandler<CreateOfflineCourierZonePriceCommand>
    {
        private readonly IMediator _mediator;

        public CreateOfflineCourierZonePriceCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateOfflineCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            if (request.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All || request.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Chapar)
            {
                await _mediator.Send(new CreateChaparCourierZonePriceCommand(), cancellationToken);
            }
            if (request.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.All || request.CourierCode == (int)SharedKernel.Common.Enums.CourierCode.Post)
            {
                await _mediator.Send(new CreatePostCourierZonePriceCommand(), cancellationToken);
            }
            return Unit.Value;
        }
    }
}
