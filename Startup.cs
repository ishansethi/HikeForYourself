using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hikeforyourselfver3.Startup))]
namespace hikeforyourselfver3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
