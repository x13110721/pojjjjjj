using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StuffStore.WebUI.Startup))]
namespace StuffStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
