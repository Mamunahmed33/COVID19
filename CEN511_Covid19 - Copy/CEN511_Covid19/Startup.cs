using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CEN511_Covid19.Startup))]
namespace CEN511_Covid19
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
