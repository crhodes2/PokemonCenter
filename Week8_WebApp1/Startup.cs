using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week8_WebApp1.Startup))]
namespace Week8_WebApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
