using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Postex.Product.ServiceApi.Extensions
{
    public class HangfireAuthAdmin : IDashboardAuthorizationFilter
    {
        private readonly string _adminRole;
        private readonly IWebHostEnvironment env;

        public HangfireAuthAdmin(IConfiguration configuration, IWebHostEnvironment env)
        {
            _adminRole = "Admin";
            this.env = env;
        }

        public bool Authorize([NotNull] DashboardContext context)
        {
            if (env.IsDevelopment())
                return true;

            var httpContext = context.GetHttpContext();

            return httpContext.User.Identity.IsAuthenticated && httpContext.User.IsInRole(_adminRole);
        }
    }
}
