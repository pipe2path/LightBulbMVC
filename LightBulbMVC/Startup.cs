using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LightBulbMVC.Startup))]
namespace LightBulbMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
