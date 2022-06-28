using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProektSept.Startup))]
namespace ProektSept
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
