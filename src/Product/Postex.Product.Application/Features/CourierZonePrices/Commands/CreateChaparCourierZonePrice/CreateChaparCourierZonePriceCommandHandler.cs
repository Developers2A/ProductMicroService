using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices;
using Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetPrice;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateChaparCourierZonePrice
{
    public class CreateChaparCourierZonePriceCommandHandler : IRequestHandler<CreateChaparCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;
        private readonly IReadRepository<CourierZonePriceTemplate> _courierZonePriceTemplateRepository;
        private readonly IMediator _mediator;

        public CreateChaparCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator)
        {
            _courierZonePriceWriteRepository = writeRepository;
            _courierZonePriceTemplateRepository = courierZonePriceTemplateRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateChaparCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            var chaparTemplates = await _courierZonePriceTemplateRepository.TableNoTracking.Include(x => x.CourierService)
                .Where(x => x.CourierService.Courier.Code == Couriers.Chapar).ToListAsync();
            if (chaparTemplates != null && chaparTemplates.Any())
            {
                await SavePrices(chaparTemplates);
            }
            return Unit.Value;
        }

        private async Task SavePrices(List<CourierZonePriceTemplate> chaparTemplates)
        {
            try
            {
                foreach (var template in chaparTemplates)
                {
                    await CreateZonePrice(template);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task CreateZonePrice(CourierZonePriceTemplate template)
        {
            var courierZonePrices = new List<CreateCourierZonePriceCommand>();
            var weight = template.Weight;
            var index = 0;
            var method = "11";
            if (template.CourierService.Code == CourierServiceCode.ChaparExpress)
            {
                method = "6";
            }

            while (weight <= 30000)
            {
                var price = await _mediator.Send(new GetChaparPriceQuery()
                {
                    Order = new ChaparOrder()
                    {
                        Cod = 0,
                        Origin = template.FromCity.ToString(),
                        Destination = template.ToCity.ToString(),
                        Value = 50000,
                        Method = method
                    }
                });
                if (price.IsSuccess)
                {
                    courierZonePrices.Add(new CreateCourierZonePriceCommand()
                    {
                        BuyPrice = price.Data.Objects.Order.Quote,
                        SellPrice = 0,
                        Weight = weight,
                        FromCourierZoneId = template.FromCourierZoneId,
                        ToCourierZoneId = template.ToCourierZoneId,
                        CourierServiceId = template.CourierServiceId
                    });

                    index += 1;
                    weight = index == 1 ? 1000 : weight + 1000;
                }
            }

            await _mediator.Send(
                new CreateCourierZonePricesCommand()
                {
                    CourierZonePrices = courierZonePrices
                }
            );
        }
    }
}
