using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder
{
    public class CreateTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffCreateOrderResponse>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        //153 : پیک تعارف
        //151 : پست پیشتاز
        [JsonProperty("carrierId")]
        public int CarrierId { get; set; }

        [JsonProperty("paymentMethodId")]
        public int PaymentMethodId { get; set; }

        [JsonProperty("cityId")]
        public string CityId { get; set; }

        [JsonProperty("productTitles")]
        public string ProductTitles { get; set; }

        [JsonProperty("totalWeight")]
        public int TotalWeight { get; set; }

        [JsonProperty("totalPrice")]
        public int TotalPrice { get; set; }
    }
}
