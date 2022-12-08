using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Chapar;

namespace Product.Application.Features.CourierServices.Chapar.Queries.Price
{
    public class GetChaparPriceQuery : ITransactionRequest<BaseResponse<ChaparGetPriceResponse>>
    {
        [JsonProperty("order")]
        public ChaparOrder Order { get; set; }
    }

    public class ChaparOrder
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("sender_code")]
        public int SenderCode { get; set; }

        [JsonProperty("receiver_code")]
        public string ReceiverCode { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("payment_terms")]
        public int PaymentTerms { get; set; }

        [JsonProperty("nv_value")]
        public int InvValue { get; set; }
    }

}
