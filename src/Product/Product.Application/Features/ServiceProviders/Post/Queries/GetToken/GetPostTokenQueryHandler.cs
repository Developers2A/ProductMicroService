using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Product.Application.Dtos.CourierServices.Post;
using Product.Domain.Posts;
using System.Net.Http.Headers;

namespace Product.Application.Features.ServiceProviders.Post.Queries.GetToken
{
    public class GetPostTokenQueryHandler : IRequestHandler<GetPostTokenQuery, string>
    {
        private readonly IConfiguration _configuration;
        private readonly CourierConfig _gateway;
        private readonly IWriteRepository<PostToken> _postTokenWriteRepository;
        private readonly IReadRepository<PostToken> _postTokenReadRepository;

        public GetPostTokenQueryHandler(IConfiguration configuration,
            IWriteRepository<PostToken> postTokenWriteRepository,
            IReadRepository<PostToken> postTokenReadRepository)
        {
            _configuration = configuration;
            _gateway = _configuration.GetSection(nameof(CourierSetting)).Get<CourierSetting>().Post;
            _postTokenWriteRepository = postTokenWriteRepository;
            _postTokenReadRepository = postTokenReadRepository;
        }

        public async Task<string> Handle(GetPostTokenQuery request, CancellationToken cancellationToken)
        {
            var postToken = await _postTokenReadRepository.TableNoTracking.FirstOrDefaultAsync(x => x.CreatedOn <= DateTime.Now && x.CreatedOn.AddMinutes(58) > DateTime.Now);

            if (postToken != null)
            {
                return postToken.Token;
            }
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
            await _postTokenWriteRepository.AddAsync(new PostToken()
            {
                Token = resModel.Token
            });
            return resModel.Token;
        }
    }
}
