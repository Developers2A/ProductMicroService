﻿using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Mahex.Common;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.CourierServices.Mahex.Commands.CreateOrder
{
    public class CreateMahexOrderCommand : ITransactionRequest<BaseResponse<PostCreateOrderResponse>>
    {
        [JsonProperty("from_address")]
        public MahexAddressDetails FromAddress { get; set; }

        [JsonProperty("to_address")]
        public MahexAddressDetails ToAddress { get; set; }

        [JsonProperty("parcels")]
        public List<MahexGetPriceParcel> Parcels { get; set; }

        [JsonProperty("price_items")]
        public List<MahexPriceItem> PriceItems { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("cod_amount")]
        public decimal CodAmount { get; set; }

        [JsonProperty("charge_party")]
        public string ChargeParty { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethod { get; set; }

        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }

        [JsonProperty("delivery_time_from")]
        public string DeliveryTimeFrom { get; set; }

        [JsonProperty("delivery_time_to")]
        public string DeliveryTimeTo { get; set; }
    }
}
