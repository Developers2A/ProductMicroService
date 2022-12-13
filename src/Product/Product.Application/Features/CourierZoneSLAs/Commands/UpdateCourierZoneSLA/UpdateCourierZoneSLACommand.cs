using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneSLAs.Commands.UpdateCourierZoneSLA
{
    public class UpdateCourierZoneSLACommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StateId { get; set; }
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
        public int ZoneId { get; set; }
        public int SLAId { get; set; }
    }
}
