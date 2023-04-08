using MediatR;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.Product.Application.Features.CourierServices.Queries;
using Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateWeight;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommandHandler : IRequestHandler<EditWeightCommand, BaseResponse<ParcelResponseDto>>
    {
        private readonly IMediator _mediator;
        private EditWeightCommand _command;
        private CourierServiceCommonDto _courierInfo;

        public EditWeightCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<ParcelResponseDto>> Handle(EditWeightCommand command, CancellationToken cancellationToken)
        {
            _command = command;

            if (_command.Courier.ServiceType != (int)SharedKernel.Common.Enums.CourierServiceCode.PostPishtaz &&
                _command.Courier.ServiceType != (int)SharedKernel.Common.Enums.CourierServiceCode.PostSefareshi &&
                _command.Courier.ServiceType != (int)SharedKernel.Common.Enums.CourierServiceCode.PostVizhe)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = false,
                    Message = "این کوریر این امکان را ندارد"
                };
            }

            if (string.IsNullOrWhiteSpace(_command.PostEcommerceShopId))
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = false,
                    Message = "post ecommerce shop id is missing"
                };

            await SetCourierInfo();
            return await EditPostWeight();
        }

        private async Task SetCourierInfo()
        {
            var couriers = await _mediator.Send(new GetCourierServicesCommonQuery
            {
                CourierServiceCode = _command.Courier.ServiceType
            });

            _courierInfo = couriers.FirstOrDefault()!;
        }

        private async Task<BaseResponse<ParcelResponseDto>> EditPostWeight()
        {
            var result = await EditPostOrder();
            if (result.IsSuccess && result.Data != null)
            {
                return new BaseResponse<ParcelResponseDto>()
                {
                    IsSuccess = result.IsSuccess,
                    Message = result.Message,
                    Data = new ParcelResponseDto()
                    {
                        AdditionalData = new AdditionalDataResponseDto()
                        {
                            GeneratedPostCode = result.Data != null ? _command.ParcelCode : ""
                        },
                        Shipments = new List<ShipmentResponseDto>()
                        {
                            new ShipmentResponseDto()
                            {
                                Courier = new CourierResponseDto()
                                {
                                    Courier = _courierInfo.CourierName,
                                    Service = _courierInfo.CourierServiceName,
                                    TransitTime = _courierInfo.Days,
                                    Description = "",
                                },
                                Step = 1,
                                Tracking = new TrackingResponseDto()
                                {
                                    Barcode = result.Data != null ? _command.ParcelCode : "",
                                    TrackingNumber = result.Data != null ? _command.ParcelCode : ""
                                },
                                ShippingRate = new ShippingRateResponseDto()
                                {
                                    BuyPrice = result.Data!.PostFare,
                                    SalePrice = result.Data.TotalPrice,
                                    Vat = result.Data.Tax,
                                    PostPrice = new PostPriceResponseDto()
                                    {
                                        PostFare =  result.Data.PostFare,
                                        TotalPrice = result.Data.TotalPrice,
                                        COD = result.Data.COD,
                                        DeliveryNotifyPrice = result.Data.DeliveryNotifyPrice,
                                        DiscountAmount = result.Data.DiscountAmount,
                                        DiscountPercent = result.Data.DiscountPercent,
                                        EcommercePrice = result.Data.EcommercePrice,
                                        ElectronicIDPrice =  result.Data.ElectronicIDPrice,
                                        InsurancePrice =  result.Data.InsurancePrice,
                                        NonStandardPrice =  result.Data.NonStandardPrice,
                                        PostPayFarePrice =  result.Data.PostPayFarePrice,
                                        PostPrice =  result.Data.PostPrice,
                                        SendPlacePrice =  result.Data.SendPlacePrice,
                                        Tax = result.Data.Tax,
                                        SMSPrice = result.Data.SMSPrice
                                    }
                                }
                            }
                        },
                        IsOversized = false,
                        ServiceCategory = "",
                        ValueAddedService = new List<ValueAddedServiceResponseDto>()
                    }
                };
            }
            return new BaseResponse<ParcelResponseDto>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
            };
        }

        private async Task<BaseResponse<PostEditWeightResponse>> EditPostOrder()
        {
            var createPostOrderCommand = new UpdatePostWeightCommand()
            {
                ParcelCode = _command.ParcelCode,
                Weight = _command.Weight,
                ShopID = Convert.ToInt32(_command.PostEcommerceShopId),
                ParcelValue = _command.ParcelValue,
                NonStandardPackage = _command.NonStandardPackage,
            };
            var result = await _mediator.Send(createPostOrderCommand);

            return new BaseResponse<PostEditWeightResponse>()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                Data = result.Data
            };
        }
    }
}
