using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRManager_new_client_web.Startup))]
namespace TRManager_new_client_web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
