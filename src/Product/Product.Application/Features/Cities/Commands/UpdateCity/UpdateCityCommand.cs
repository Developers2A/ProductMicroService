using Product.Application.Contracts;

namespace Product.Application.Features.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
        public int StateId { get; set; }
    }
}
