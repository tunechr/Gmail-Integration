using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Google.Authentication.Startup))]
namespace Google.Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
