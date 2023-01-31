using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.States.Commands.UpdateState
{
    public class UpdateStateCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
    }
}
