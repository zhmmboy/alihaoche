using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Car.MvcWeb.Startup))]
namespace Car.MvcWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
