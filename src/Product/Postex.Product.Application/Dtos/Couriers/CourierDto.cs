using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.Couriers
{
    public class CourierDto
    {
        public int Id { get; set; }
        public SharedKernel.Common.Enums.CourierCode Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
