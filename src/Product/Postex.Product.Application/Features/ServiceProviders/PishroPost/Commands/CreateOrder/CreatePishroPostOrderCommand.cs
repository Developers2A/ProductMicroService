using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.PishroPost;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder
{
    public class CreatePishroPostOrderCommand : ITransactionRequest<BaseResponse<PishroPostCreateOrderResponse>>
    {
        [JsonProperty("user")]
        public PishroPostUser User { get; set; }

        [JsonProperty("bulk")]
        public List<PishroPostBulk> Bulk { get; set; }
    }

    public class PishroPostUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class PishroPostBulk
    {
        [JsonProperty("cn")]
        public PishroPostCn cn { get; set; }

        [JsonProperty("sender")]
        public PishroPostSenderReceiver sender { get; set; }

        [JsonProperty("receiver")]
        public PishroPostSenderReceiver receiver { get; set; }
    }

    public class PishroPostCn
    {
        [JsonProperty("reference")]
        public string reference { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("assinged_pieces")]
        public string assinged_pieces { get; set; }

        [JsonProperty("service")]
        public string service { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("inv_value")]
        public int inv_value { get; set; }

        [JsonProperty("payment_term")]
        public string payment_term { get; set; }

        [JsonProperty("weight")]
        public string weight { get; set; }

        [JsonProperty("content")]
        public string content { get; set; }

        [JsonProperty("note")]
        public string note { get; set; }
    }

    public class PishroPostSenderReceiver
    {
        [JsonProperty("person")]
        public string person { get; set; }

        [JsonProperty("company")]
        public string company { get; set; }

        [JsonProperty("city_no")]
        public string city_no { get; set; }

        [JsonProperty("telephone")]
        public string telephone { get; set; }

        [JsonProperty("mobile")]
        public string mobile { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("address")]
        public string address { get; set; }
    }
}
