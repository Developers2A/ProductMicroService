using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Provinces.Commands.UpdateProvince
{
    public class UpdateProvinceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
    }
}
