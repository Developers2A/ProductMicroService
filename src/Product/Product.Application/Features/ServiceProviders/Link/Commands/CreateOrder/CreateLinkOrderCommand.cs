using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Link;

namespace Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder
{
    public class CreateLinkOrderCommand : ITransactionRequest<BaseResponse<LinkCreateOrderResponse>>
    {
        [JsonProperty("orderCode")]
        public string OrderCode { get; set; }

        [JsonProperty("items")]
        public List<LinkOrder> Orders { get; set; }
    }

    public class LinkOrder
    {
        [JsonProperty("companyTrackingCode")]
        public string CompanyTrackingCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("deliveryType")]
        public int DeliveryType { get; set; }

        [JsonProperty("shift")]
        public int Shift { get; set; }

        [JsonProperty("parcelType")]
        public int ParcelType { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("sendDate")]
        public DateTime SendDate { get; set; }

        [JsonProperty("cellPhone")]
        public string CellPhone { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("parcelValue")]
        public decimal ParcelValue { get; set; }

        [JsonProperty("weight")]
        public decimal? Weight { get; set; }

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("return")]
        public int Return { get; set; }

        [JsonProperty("describtion")]
        public string Describtion { get; set; }

        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }

        [JsonProperty("generateBarcode")]
        public int GenerateBarcode { get; set; }

        [JsonProperty("Ptype")]
        public int PType { get; set; } = 1;
    }
}
