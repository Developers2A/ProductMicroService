﻿using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.GetProvinces
{
    public class GetTaroffProvincesQuery : ITransactionRequest<BaseResponse<List<TaroffState>>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
