using Postex.Pudo.Application.Contracts;
using Postex.Pudo.Application.Dtos.DigikalaPudo;
using Postex.SharedKernel.Common;

namespace Postex.Pudo.Application.Features.DigikalaPudoPrice.Queries.DigikalaPudoPrices;

public class GetDigikalaPudoPricesQuery : ITransactionRequest<BaseResponse<DigikalaPackageDto>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? ParcelCode { get; set; }
}
