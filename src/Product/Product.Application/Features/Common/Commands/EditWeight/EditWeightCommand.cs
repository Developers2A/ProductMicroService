using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string ParcelId { get; set; }
        public string SenderMobile { get; set; }
        public int Weight { get; set; }
        public long ParcelValue { get; set; }
        public bool NonStandardPackage { get; set; }
    }
}
