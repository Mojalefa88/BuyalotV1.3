using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuyalotV1._3.Startup))]
namespace BuyalotV1._3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
