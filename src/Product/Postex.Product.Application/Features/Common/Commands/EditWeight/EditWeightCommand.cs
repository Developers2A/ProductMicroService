using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
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
