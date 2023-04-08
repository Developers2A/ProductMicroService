using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices;
using Postex.Product.Application.Features.PostShops.Queries;
using Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetPrice;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreatePostCourierZonePrice
{
    public class CreatePostCourierZonePriceCommandHandler : IRequestHandler<CreatePostCourierZonePriceCommand>
    {
        private readonly IWriteRepository<CourierZonePrice> _courierZonePriceWriteRepository;
        private readonly IReadRepository<CourierZonePrice> _courierZonePriceReadRepository;
        private readonly IReadRepository<CourierZonePriceTemplate> _courierZonePriceTemplateRepository;
        private readonly IMediator _mediator;

        public CreatePostCourierZonePriceCommandHandler(IWriteRepository<CourierZonePrice> writeRepository, IReadRepository<CourierZonePriceTemplate> courierZonePriceTemplateRepository, IMediator mediator, IReadRepository<CourierZonePrice> courierZonePriceReadRepository)
        {
            _courierZonePriceWriteRepository = writeRepository;
            _courierZonePriceTemplateRepository = courierZonePriceTemplateRepository;
            _mediator = mediator;
            _courierZonePriceReadRepository = courierZonePriceReadRepository;
        }

        public async Task<Unit> Handle(CreatePostCourierZonePriceCommand request, CancellationToken cancellationToken)
        {
            var postTemplates = await _courierZonePriceTemplateRepository.TableNoTracking.Include(x => x.CourierService)
                .Where(x => x.CourierService.Courier.Code == CourierCode.Post).ToListAsync();
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

            var postShop = await _mediator.Send(new GetPostShopsQuery()
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
                    ShopID = postShop.FirstOrDefault()!.ShopId,
                    PayTypeID = 1,
                    SMSService = false,
                    ParcelValue = 50000
                });

                if (price.IsSuccess)
                {
                    var existing = _courierZonePriceReadRepository.TableNoTracking.FirstOrDefaultAsync(x => x.BuyPrice == price.Data.PostPrice &&
                    x.FromCourierZoneId == template.FromCourierZoneId && x.ToCourierZoneId == template.ToCourierZoneId && x.Weight == weight);
                    if (existing != null)
                    {
                        courierZonePrices.Add(new CreateCourierZonePriceCommand()
                        {
                            BuyPrice = price.Data.PostPrice,
                            SellPrice = 0,
                            Weight = weight,
                            FromCourierZoneId = template.FromCourierZoneId,
                            ToCourierZoneId = template.ToCourierZoneId,
                            CourierServiceId = template.CourierServiceId,
                            SameProvince = template.SameProvince
                        });
                    }
                }
                index += 1;
                weight = index == 1 ? 1000 : weight + 1000;
            }

            if (courierZonePrices.Any())
            {
                await _mediator.Send(
                     new CreateCourierZonePricesCommand()
                     {
                         CourierZonePrices = courierZonePrices
                     }
                );
            }
        }
    }
}
