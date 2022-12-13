using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneSLAs.Commands.CreateCourierZoneSLA
{
    public class CreateCourierZoneSLACommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
        public int? ZoneId { get; set; }
        public int SLAId { get; set; }
    }
}
