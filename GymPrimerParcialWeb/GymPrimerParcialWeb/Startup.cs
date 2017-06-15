using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymPrimerParcialWeb.Startup))]
namespace GymPrimerParcialWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
