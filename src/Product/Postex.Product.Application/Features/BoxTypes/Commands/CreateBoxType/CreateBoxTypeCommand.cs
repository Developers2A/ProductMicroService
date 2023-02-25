using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxTypes.Commands.CreateBoxType
{
    public class CreateBoxTypeCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
