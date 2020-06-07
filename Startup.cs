using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheProfessionalStalker.Startup))]
namespace TheProfessionalStalker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
