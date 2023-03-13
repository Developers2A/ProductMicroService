using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Provinces.Commands.CreateProvince
{
    public class CreateProvinceCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
    }
}
