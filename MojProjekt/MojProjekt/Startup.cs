using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MojProjekt.Startup))]
namespace MojProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
