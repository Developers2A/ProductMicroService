using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices;
using Product.Application.Features.ServiceProviders.Chapar.Queries.GetPrice;
using Product.Application.Features.Weights.Queries;
using Product.Domain.Enums;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateChaparCourierZonePrice
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
                .Where(x => x.CourierService.Courier.Code == CourierCode.Chapar).ToListAsync();
            if (chaparTemplates != null && chaparTemplates.Any())
            {
                await SavePrices(chaparTemplates);
            }
            return Unit.Value;
        }

        private async Task SavePrices(List<CourierZonePriceTemplate> chaparTemplates)
        {
            var courierZonePrices = new List<CreateCourierZonePriceCommand>();
            var weights = await _mediator.Send(new GetWeightsQuery());

            foreach (var item in chaparTemplates)
            {
                for (int i = 1; i < 2; i++)
                {
                    foreach (var weight in weights)
                    {
                        var priceRequest = new GetChaparPriceQuery()
                        {
                            Order = new ChaparOrder()
                            {
                                Weight = (decimal)weight.PostageWeight * 1000,
                                Value = 300000,
                                Origin = item.FromCity.ToString(),
                                Destination = item.ToCity.ToString(),
                                Method = item.CourierService.Code == CourierServiceCode.Chapar ? "11" : "6"
                            }
                        };

                        var price = await _mediator.Send(priceRequest);

                        if (price.IsSuccess)
                        {
                            courierZonePrices.Add(new CreateCourierZonePriceCommand()
                            {
                                BuyPrice = price.Data.Objects.Order.Quote,
                                SellPrice = 0,
                                Weight = item.Weight,
                                FromCourierZoneId = item.FromCourierZoneId,
                                ToCourierZoneId = item.ToCourierZoneId,
                                CourierServiceId = item.CourierServiceId
                            });
                        }
                    }
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
