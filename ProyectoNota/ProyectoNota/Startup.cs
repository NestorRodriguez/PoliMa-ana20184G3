using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoNota.Startup))]
namespace ProyectoNota
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
