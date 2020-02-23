using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCM.Cocina.WebApp3.Startup))]
namespace PCM.Cocina.WebApp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
