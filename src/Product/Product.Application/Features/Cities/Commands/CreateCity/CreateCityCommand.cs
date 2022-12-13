using Product.Application.Contracts;

namespace Product.Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
        public int StateId { get; set; }
    }
}
