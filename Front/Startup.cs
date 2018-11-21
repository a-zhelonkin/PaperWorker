using Front;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Front
{
    public partial class Startup
    {
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}