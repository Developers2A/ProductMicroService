using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Mahex.Queries.Track
{
    public class GetMahexTrackQuery : ITransactionRequest<BaseResponse<MahexTrackResponse>>
    {
        [JsonProperty("waybill_number")]
        public string WaybillNumber { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("part_number")]
        public string PartNumber { get; set; }
    }
}
