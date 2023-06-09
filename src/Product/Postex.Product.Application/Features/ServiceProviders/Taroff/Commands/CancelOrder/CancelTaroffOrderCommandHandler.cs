﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using System.Text;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommandHandler : IRequestHandler<CancelTaroffOrderCommand, BaseResponse<TaroffCancelResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CancelTaroffOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Taroff;
        }

        public async Task<BaseResponse<TaroffCancelResponse>> Handle(CancelTaroffOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                var resModel = JsonConvert.DeserializeObject<TaroffCancelResponse>(res);
                if (resModel!.State == "ok")
                {
                    return new(true, "success", resModel);
                }

                return new(false, resModel.State);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Taroff " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CancelTaroffOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);
            request.Token = _gateway.Token;
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");
            var pUrl = new Uri($"{_gateway.BaseUrl}/order/cancel");

            return await client.PostAsync(pUrl, content);
        }
    }
}
