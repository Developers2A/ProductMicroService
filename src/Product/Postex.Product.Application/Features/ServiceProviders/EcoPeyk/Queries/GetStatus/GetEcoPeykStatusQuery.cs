using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.EcoPeyk;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetStatus
{
    public class GetEcoPeykStatusQuery : ITransactionRequest<BaseResponse<EcoPeykOrderStatusResponse>>
    {
        public string Code { get; set; }
    }
}
