using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppHIDRONAMIC.Startup))]
namespace WebAppHIDRONAMIC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
