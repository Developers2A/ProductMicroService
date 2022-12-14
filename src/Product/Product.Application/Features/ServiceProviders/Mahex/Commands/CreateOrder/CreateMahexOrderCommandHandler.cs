﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using System.Text;

namespace Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder
{
    public class CreateMahexOrderCommandHandler : IRequestHandler<CreateMahexOrderCommand, BaseResponse<PostCreateOrderResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;

        public CreateMahexOrderCommandHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Mahex;
        }

        public async Task<BaseResponse<PostCreateOrderResponse>> Handle(CreateMahexOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await SetHttpRequest(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new(false, response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();

                var resModel = JsonConvert.DeserializeObject<PostResponse<PostCreateOrderResponse>>(res);
                if (resModel!.ResCode == 0)
                {
                    return new(true, "success", resModel!.Data);
                }

                return new(false, resModel!.ResMsg!);
            }
            catch (Exception ex)
            {
                return new(false, "An error has occurred in the Service Mahex " + ex.Message);
            }
        }

        private async Task<HttpResponseMessage> SetHttpRequest(CreateMahexOrderCommand request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl);

            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Parcel/New");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
