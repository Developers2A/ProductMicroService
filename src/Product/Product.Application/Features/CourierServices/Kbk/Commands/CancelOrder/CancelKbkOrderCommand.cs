using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;

namespace Product.Application.Features.CourierServices.Kbk.Commands.CancelOrder
{
    public class CancelKbkOrderCommand : ITransactionRequest<BaseResponse<KbkCancelResponse>>
    {
        public string ApiCode { get; set; }
        public string ShipmentCode { get; set; }
    }
}
