using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Speed.Dtos;

namespace Product.Application.Features.CourierServices.Speed.Commands.CancelOrder
{
    public class CancelSpeedOrderCommand : ITransactionRequest<BaseResponse<SpeedCancelOrderResponse>>
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string CellPhone { get; set; }

        [JsonProperty("addr")]
        public string Address { get; set; }

        [JsonProperty("qty"), JsonRequired]
        public int Qty { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("vol")]
        public int Vol { get; set; }

        [JsonProperty("packing")]
        public string Packing { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("payment")]
        public int Payment { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("orderID")]
        public string OrderId { get; set; }

        [JsonProperty("shift")]
        public int Shift { get; set; }

        [JsonProperty("req_date")]
        public string ReqDate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("shipment")]
        public int Shipment { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_lastname")]
        public string SenderLastName { get; set; }

        [JsonProperty("sender_city")]
        public string SenderCity { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        [JsonProperty("sender_cell")]
        public string SenderCellPhone { get; set; }

        [JsonProperty("sender_addr")]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_location")]
        public string SenderLocation { get; set; }
    }
}
