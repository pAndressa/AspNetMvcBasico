using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspMVC.Startup))]
namespace AspMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
