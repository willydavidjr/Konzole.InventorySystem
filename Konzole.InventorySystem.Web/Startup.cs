using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Konzole.InventorySystem.Web.Startup))]
namespace Konzole.InventorySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
