using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gmail_Integration.Startup))]
namespace Gmail_Integration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
