using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Bsw;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Bsw.Commands.CreateOrder
{
    public class CreateBswOrderCommand : ITransactionRequest<BaseResponse<BswCreateOrderResponse>>
    {
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderPostCode { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverPostCode { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public string Content { get; set; }
        public string ContentValue { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Countrycode { get; set; }
        public int ParcelType { get; set; }
        public int ServiceType { get; set; }
    }
}
