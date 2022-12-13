using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.CourierServices.Common.Commands.CreateOrder
{
    public class CreateOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public string ClientOrderID { get; set; }
        public string CustomerNID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFamily { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerAddress { get; set; }
        public string ParcelContent { get; set; }
        public int ParcelCategoryID { get; set; }
    }
}
