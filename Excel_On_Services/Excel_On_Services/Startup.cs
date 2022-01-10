using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Excel_On_Services.Startup))]
namespace Excel_On_Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
