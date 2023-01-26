using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Helper;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetCollectionPrices;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionAndCollectionPrices;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionPrices;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQueryHandler : IRequestHandler<GetBasketPricesQuery, PriceResponseDto>
    {
        private readonly IMediator _mediator;
        private Basket _basket;
        private List<CollectionDistributionPriceDto> _courierZoneCollectionDistributionPrices;

        public GetBasketPricesQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PriceResponseDto> Handle(GetBasketPricesQuery query, CancellationToken cancellationToken)
        {
            _basket = query.Basket;

            var basketValidate = await Validate();
            if (basketValidate != null)
            {
                return basketValidate;
            }

            switch (_basket.ServiceId)
            {
                case ServiceType.DistributionAndCollectionService:
                    {
                        return await _mediator.Send(new GetDistributionAndCollectionPricesQuery()
                        {
                            Basket = _basket,
                            CollectionDistributionPrices = _courierZoneCollectionDistributionPrices
                        });
                    }
                case ServiceType.CollectionService:
                    {
                        return await _mediator.Send(new GetCollectionPricesQuery()
                        {
                            Basket = _basket,
                            CollectionDistributionPrices = _courierZoneCollectionDistributionPrices
                        });
                    }
                case ServiceType.DistributionService:
                    {
                        return await _mediator.Send(new GetDistributionPricesQuery()
                        {
                            Basket = _basket,
                            CollectionDistributionPrices = _courierZoneCollectionDistributionPrices
                        });
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task<PriceResponseDto?> Validate()
        {
            var validateBasket = ValidateBasket();
            if (validateBasket != null)
            {
                return validateBasket;
            }

            return await ValidateCourierLimit();
        }

        private PriceResponseDto? ValidateBasket()
        {
            var response = new PriceResponseDto
            {
                BasketId = _basket.BasketId
            };

            if (!_basket.Parcels.Any())
            {
                response.ErrorResponse = "درخواست شما خالی است، لطفا بسته ها را اضافه کنید ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            if (_basket.Parcels.Any(x => x.IsCanceled == true && x.IsNew == true))
            {
                response.ErrorResponse = "بسته نمی تواند هم جدید و هم کنسلی باشد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            if (_basket.Parcels.Any(x => x.IsNew == true && (x.CollectionPrice > 0 || x.DistributionPrice > 0)))
            {
                response.ErrorResponse = "بسته جدید نباید قیمت جمع آوری و توزیع داشته باشد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            return null;
        }

        private async Task<PriceResponseDto?> ValidateCourierLimit()
        {
            var response = new PriceResponseDto
            {
                BasketId = _basket.BasketId
            };

            _courierZoneCollectionDistributionPrices = await _mediator.Send(new GetCourierZoneCollectionDistributionPricesFilterQuery()
            {
                CourierCode = _basket.CourierId
            });

            if (_courierZoneCollectionDistributionPrices == null || !_courierZoneCollectionDistributionPrices.Any())
            {
                response.ErrorResponse = "کوریر منتخب امکان جمع آوری و یا توزیع ندارد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            var maxVolume = _courierZoneCollectionDistributionPrices.Last().Volume;

            if (_basket.Parcels.Any(x => x.GetVolume() > (int)maxVolume))
            {
                response.ErrorResponse = "کوریر امکان جمع آوری و توزیع سایز درخواستی را ندارد  ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            for (int i = 0; i < _basket.Parcels.Count; i++)
            {
                if (!_courierZoneCollectionDistributionPrices.Any(x => x.CityType == _basket.Parcels[i].DestinationCityTypeId))
                {
                    response.ErrorResponse = "کوریر در شهر درخواستی سرویس نمی دهد ";
                    response.CollectionPrice = null;
                    response.DistributionPrice = null;
                    return response;
                }
            }

            if (!_courierZoneCollectionDistributionPrices.Any(x => x.CityType == _basket.CityTypeId))
            {
                response.ErrorResponse = "کوریر در شهر درخواستی سرویس نمی دهد ";
                response.CollectionPrice = null;
                response.DistributionPrice = null;
                return response;
            }

            return null;
        }
    }
}
