using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Mahex;

namespace Product.Application.Features.CourierServices.Mahex.Queries.OrderTrack
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
