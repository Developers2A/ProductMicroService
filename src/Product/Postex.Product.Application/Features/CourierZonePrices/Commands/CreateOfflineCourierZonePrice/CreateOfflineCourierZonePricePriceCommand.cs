using Postex.Product.Application.Contracts;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateOfflineCourierZonePriceCommand : ITransactionRequest
    {
        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }
    }
}
