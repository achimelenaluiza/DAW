using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proiect_final.Startup))]
namespace Proiect_final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
