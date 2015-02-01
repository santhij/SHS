using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthSystemsDemo.Startup))]
namespace HealthSystemsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
