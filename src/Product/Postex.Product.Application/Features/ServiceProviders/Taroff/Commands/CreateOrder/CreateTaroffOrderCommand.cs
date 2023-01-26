using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder
{
    public class CreateTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffCreateOrderResponse>>
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Code { get; set; }
        public string DeliverTime { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int CarrierId { get; set; }
        public int PaymentMethodId { get; set; }
        public int CityId { get; set; }
        public string ProductTitles { get; set; }
        public int TotalWeight { get; set; }
        public int TotalPrice { get; set; }
    }
}
