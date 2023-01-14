using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices;
using Product.Application.Features.PostShops.Queries;
using Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Commands.CreatePostCourierZonePrice
{
    public class CreatePostCourierZonePriceCommandHandler : IRequestHandler<CreatePostCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;
        private readonly IReadRepository<CourierZonePriceTemplate> _courierZonePriceTemplateRepository;
        private readonly IMediator _mediator;

        public CreatePostCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator)
        {
            _courierZonePriceWriteRepository = writeRepository;
            _courierZonePriceTemplateRepository = courierZonePriceTemplateRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreatePostCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            var postTemplates = await _courierZonePriceTemplateRepository.TableNoTracking.Include(x => x.CourierService)
                .Where(x => x.CourierService.Courier.Code == CourierCode.Post && x.FromCourierZoneId == 11 && x.ToCourierZoneId == 11 && x.SameState == false).ToListAsync();
            await SavePrices(postTemplates);
            return Unit.Value;
        }

        private async Task SavePrices(List<CourierZonePriceTemplate> postTemplates)
        {
            try
            {
                foreach (var template in postTemplates)
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

            var postShop = await _mediator.Send(new GetPostShopByCityCodeQuery()
            {
                CityCode = template.FromCity
            });

            var serviceType = 1;
            if (template.CourierService.Code == CourierServiceCode.PostSefareshi)
            {
                serviceType = 2;
            }
            if (template.CourierService.Code == CourierServiceCode.PostVizhe)
            {
                serviceType = 3;
            }

            while (weight <= 30000)
            {
                var price = await _mediator.Send(new GetPostPriceQuery()
                {
                    ToCityID = template.ToCity,
                    ServiceTypeID = serviceType,
                    CollectNeed = false,
                    NonStandardPackage = false,
                    Weight = weight,
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
                        Weight = weight,
                        FromCourierZoneId = template.FromCourierZoneId,
                        ToCourierZoneId = template.ToCourierZoneId,
                        CourierServiceId = template.CourierServiceId,
                        SameState = template.SameState
                    });
                }
                index += 1;
                weight = index == 1 ? 1000 : weight + 1000;
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
