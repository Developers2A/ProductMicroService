﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;

namespace Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetCities
{
    public class GetChaparCitiesQueryHandler : IRequestHandler<GetChaparCitiesQuery, BaseResponse<List<ChaparCity>>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetChaparCitiesQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Chapar;
        }

        public async Task<BaseResponse<List<ChaparCity>>> Handle(GetChaparCitiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<ChaparGetCitiesResponse>(res);
                if (resModel.result)
                {
                    return new(true, "success", resModel.Objects.city);
                }
                return new(false, resModel.message);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Chapar " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(GetChaparCitiesQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            var serializedModel = JsonConvert.SerializeObject(request);
            var model = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("input", serializedModel.ToString()),
            });

            var pUrl = new Uri($"{_gateway.BaseUrl}/get_city");
            return await client.PostAsync(pUrl, model);
        }
    }
}
