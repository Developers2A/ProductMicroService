using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices;
using Product.Application.Features.PostShops.Queries;
using Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Product.Domain.Enums;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateCourierZonePriceCommandHandler : IRequestHandler<CreateOfflineCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;
        private readonly IReadRepository<CourierZonePriceTemplate> _courierZonePriceTemplateRepository;
        private readonly IMediator _mediator;

        public CreateCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator)
        {
            _courierZonePriceWriteRepository = writeRepository;
            _courierZonePriceTemplateRepository = courierZonePriceTemplateRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateOfflineCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            var templates = _courierZonePriceTemplateRepository.TableNoTracking.Include(x => x.CourierService);
            var postTemplates = templates.Where(x => x.CourierService.Courier.Code == CourierCode.Post);
            await SavePostPrices(postTemplates);
            return Unit.Value;
        }

        private async Task SavePostPrices(IQueryable<CourierZonePriceTemplate> postTemplates)
        {
            var courierZonePrices = new List<CreateCourierZonePriceCommand>();

            foreach (var item in postTemplates)
            {
                var postShop = await _mediator.Send(new GetPostShopByCityCodeQuery()
                {
                    CityCode = item.FromCity
                });

                for (int i = 1; i < 3; i++)
                {
                    var price = await _mediator.Send(new GetPostPriceQuery()
                    {
                        ToCityID = item.ToCity,
                        ServiceTypeID = i,
                        CollectNeed = false,
                        NonStandardPackage = false,
                        Weight = item.Weight,
                        ShopID = postShop.ShopId,
                        PayTypeID = 1,
                        SMSService = false,
                        ParcelValue = 50000
                    });

                    if (price.IsSuccess)
                    {
                        courierZonePrices.Add(new CreateCourierZonePriceCommand()
                        {
                            BuyPrice = price.Data.PostPrice,
                            SellPrice = 0,
                            Weight = item.Weight,
                            FromCourierZoneId = item.FromCourierZoneId,
                            ToCourierZoneId = item.ToCourierZoneId,
                            CourierServiceId = item.CourierServiceId
                        });
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
