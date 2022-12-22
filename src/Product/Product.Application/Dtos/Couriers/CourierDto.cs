using Product.Domain.Enums;

namespace Product.Application.Dtos.Couriers
{
    public class CourierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourierCode Code { get; set; }
        public bool IsActive { get; set; }
    }
}
