﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.Post;
using System.Net.Http.Headers;

namespace Product.Application.Features.CourierServices.Tarrof.Queries.GetPrice
{
    public class GetTokenQueryHandler : IRequestHandler<GetPriceQuery, string>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public GetTokenQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
        }

        public async Task<string> Handle(GetPriceQuery request, CancellationToken cancellationToken)
        {
            var formContent = new FormUrlEncodedContent(new[]
             {
                new KeyValuePair<string, string>("username", _gateway.UserName),
                new KeyValuePair<string, string>("password", _gateway.Password),
                new KeyValuePair<string, string>("grant_type", "password")
            });
            var pUrl = new Uri($"{_gateway.BaseUrl}Users/Token");
            var client = new HttpClient
            {
                BaseAddress = new Uri(_gateway.BaseUrl)
            };
            client.DefaultRequestHeaders
                         .Accept
                         .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(pUrl, formContent);
            var res = await response.Content.ReadAsStringAsync();
            var resModel = JsonConvert.DeserializeObject<PostGetTokenResponse>(res);
            return resModel.Token;
        }
    }
}
