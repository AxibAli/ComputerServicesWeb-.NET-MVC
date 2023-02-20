using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerServicesWeb.Startup))]
namespace ComputerServicesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
