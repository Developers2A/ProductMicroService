using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons.EditOrder.Request;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        public int CourierCode { get; set; }
        public ParcelEditDto Parcel { get; set; }
        public string SenderMobile { get; set; }
        public ReceiverEditDto To { get; set; }
    }
}
