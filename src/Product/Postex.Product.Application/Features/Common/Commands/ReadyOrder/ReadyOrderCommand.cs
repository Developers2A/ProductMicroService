﻿using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.ReadyOrder
{
    public class ReadyOrderCommand : ITransactionRequest<BaseResponse<ReadyOrderResponse>>
    {
        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }

        [JsonPropertyName("track_code")]
        public string TrackCode { get; set; }
    }
}
