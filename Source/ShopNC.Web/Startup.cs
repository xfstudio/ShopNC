using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopNC.Web.Startup))]
namespace ShopNC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}
