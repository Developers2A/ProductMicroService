using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Chapar;
using Product.Application.Dtos.CourierServices.Chapar.Common;

namespace Product.Application.Features.CourierServices.Chapar.Commands.CreateOrder
{
    public class CreateChaparOrderCommand : ITransactionRequest<BaseResponse<ChaparCreateOrderResponse>>
    {
        [JsonProperty("user")]
        public ChaparUser User { get; set; }

        [JsonProperty("bulk")]
        public List<Bulk> Bulk { get; set; }
    }

    public class CnBulkImport
    {
        public int reference { get; set; }
        public string date { get; set; }
        public string assinged_pieces { get; set; }
        public string service { get; set; }
        public string value { get; set; }
        public int payment_term { get; set; }
        public int payment_terms { get; set; }
        public string weight { get; set; }
        public string content { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public int inv_value { get; set; }
    }

    public class Bulk
    {
        public CnBulkImport cn { get; set; }
        public ChaparSenderReceiver sender { get; set; }
        public ChaparSenderReceiver receiver { get; set; }
    }
}
