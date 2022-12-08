﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.Post;
using Product.Application.Features.CourierServices.Post.Queries.GetToken;
using System.Text;

namespace Product.Application.Features.CourierServices.Post.Queries.GetShops
{
    public class GetShopsQueryHandler : IRequestHandler<GetShopsQuery, BaseResponse<PostGetShopsResponse>>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IMediator _mediator;

        public GetShopsQueryHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _mediator = mediator;
        }

        public async Task<BaseResponse<PostGetShopsResponse>> Handle(GetShopsQuery request, CancellationToken cancellationToken)
        {
            BaseResponse<BaseResponse<PostGetShopsResponse>> result = new();
            try
            {
                string token = await _mediator.Send(new GetPostTokenQuery());
                HttpResponseMessage response = await SetHttpRequest(token, request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new AppException(response.StatusCode.ToString() + " : " + response.Content.ReadAsStringAsync().Result);
                }

                var res = await response.Content.ReadAsStringAsync();
                try
                {
                    var resModel = JsonConvert.DeserializeObject<PostResponse<PostGetShopsResponse>>(res);
                    if (resModel!.ResCode == 0)
                    {
                        return new(true, "success", resModel.Data);
                    }

                    return new(false, "fail", resModel.Data);
                }
                catch
                {
                    var resModel = JsonConvert.DeserializeObject<PostEmptyResponse>(res);
                    if (resModel!.ResCode == 2)
                    {
                        return new(false, resModel.ResMsg + "," + string.Join<string>(",", resModel.Data!.Select(x => x.ErrorMessage)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AppException("An error has occurred in the Service Post " + ex.Message);
            }
            return new(false, "fail");
        }

        private async Task<HttpResponseMessage> SetHttpRequest(string token, GetShopsQuery request)
        {
            HttpClient client = HttpClientUtilities.SetHttpClient(_gateway.BaseUrl, token);
            var serializedModel = JsonConvert.SerializeObject(request);
            var content = new StringContent(serializedModel,
                Encoding.UTF8,
                "application/json");

            var pUrl = new Uri($"{_gateway.BaseUrl}Shop/List");
            var response = await client.PostAsync(pUrl, content);
            return response;
        }
    }
}
