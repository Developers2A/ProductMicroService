using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxTypes.Commands.UpdateBoxType
{
    public class UpdateBoxTypeCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
