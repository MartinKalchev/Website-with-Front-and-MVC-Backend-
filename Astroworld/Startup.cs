using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Astroworld.Startup))]
namespace Astroworld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
