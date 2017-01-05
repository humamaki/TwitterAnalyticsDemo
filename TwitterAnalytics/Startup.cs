using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterAnalytics.Startup))]
namespace TwitterAnalytics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
