using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.WebApi.Endpoint
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiControllerWithDefaultRoute : BaseApiController
    {
    }
}
