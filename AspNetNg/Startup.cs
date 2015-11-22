using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetNg.Startup))]
namespace AspNetNg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
