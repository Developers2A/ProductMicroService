using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Settings;

public class CourierResponseTime : BaseEntity<int>
{
    public SharedKernel.Common.Enums.CourierCode CourierCode { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ResponseTime { get; set; }
    public string Api { get; set; }
}

