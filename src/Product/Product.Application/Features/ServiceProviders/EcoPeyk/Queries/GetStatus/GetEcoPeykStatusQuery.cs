using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.EcoPeyk;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetStatus
{
    public class GetEcoPeykStatusQuery : ITransactionRequest<BaseResponse<EcoPeykOrderStatusResponse>>
    {
        public string Code { get; set; }
    }
}
