namespace Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffGetProvincesResponse
    {
        public string State { get; set; }
        public List<TaroffState> Categories { get; set; }
    }

    public class TaroffState
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
