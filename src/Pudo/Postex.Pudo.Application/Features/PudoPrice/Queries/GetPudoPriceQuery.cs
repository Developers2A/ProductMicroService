using Postex.Pudo.Application.Contracts;
using Postex.Pudo.Application.Dtos.PudoPrice;
using Postex.SharedKernel.Common;

namespace Postex.Pudo.Application.Features.PudoPrice.Queries;

public class GetPudoPriceQuery : ITransactionRequest<BaseResponse<PudoPriceDto>>
{
    public string CityName { get; set; }
}
