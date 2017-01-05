using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFL.Startup))]
namespace NFL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
