using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken
{
    public class GetEcoPeykTokenQueryHandler : IRequestHandler<GetEcoPeykTokenQuery, string>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetEcoPeykTokenQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().EcoPeyk;
        }

        public async Task<string> Handle(GetEcoPeykTokenQuery request, CancellationToken cancellationToken)
        {
            request.UserName = _gateway.UserName;
            request.Password = _gateway.Password;
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}identity/login");
            var client = new HttpClient
            {
                BaseAddress = new Uri(_gateway.BaseUrl)
            };
            var response = await client.PostAsync(pUrl, content);
            var res = await response.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<EcoPeykGetTokenResponse>(res);
            return resModel.Token;
        }
    }
}
