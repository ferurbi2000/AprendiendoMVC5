using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolaMundo.Startup))]
namespace HolaMundo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
