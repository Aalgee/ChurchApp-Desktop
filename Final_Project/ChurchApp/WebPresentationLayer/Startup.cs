using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPresentationLayer.Startup))]
namespace WebPresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
