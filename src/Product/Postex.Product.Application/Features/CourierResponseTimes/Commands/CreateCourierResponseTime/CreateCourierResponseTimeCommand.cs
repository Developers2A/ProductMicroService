using Postex.Product.Application.Contracts;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.CourierResponseTimes.Commands.CreateCourierResponseTime;

public class CreateCourierResponseTimeCommand : ITransactionRequest
{
    public SharedKernel.Common.Enums.CourierCode CourierCode { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ResponseTime { get; set; }
    public string Api { get; set; }
}
