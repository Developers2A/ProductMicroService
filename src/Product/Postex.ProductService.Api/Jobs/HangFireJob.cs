using MediatR;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice;
using Postex.Product.Application.Features.PostShops.Commands.SyncPostShops;

namespace Postex.ProductService.Api.Jobs
{
    public class HangFireJob : IHangFireJob
    {
        private readonly IMediator _mediator;
        public HangFireJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SyncShops()
        {
            await _mediator.Send(new SyncPostShopsCommand()
            {
                FromDate = DateTime.Now.AddYears(-15),
                ToDate = DateTime.Now.AddYears(15)
            });
        }

        public async Task SyncPrices()
        {
            await _mediator.Send(new CreateOfflineCourierZonePriceCommand()
            {
                CourierCode = 0
            });
        }
    }
}
