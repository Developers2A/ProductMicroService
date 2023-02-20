using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string ParcelId { get; set; }
        public string SenderMobile { get; set; }
        public string Content { get; set; }
        public ReceiverDto Receiver { get; set; }
    }
}
