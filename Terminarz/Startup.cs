using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Terminarz.Startup))]
namespace Terminarz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
