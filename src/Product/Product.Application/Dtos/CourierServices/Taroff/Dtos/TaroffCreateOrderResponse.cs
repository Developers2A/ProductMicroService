namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffCreateOrderResponse
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public int Shipping { get; set; }
        public int Tax { get; set; }
    }
}
