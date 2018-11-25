using Front;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
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

//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
//            loggerFactory.AddDebug();
//
//            if (env.IsDevelopment())
//            {
//                app.UseWebpackDevMiddleware();
//            }
//
//            app.UseAuthentication();
//            app.UseStaticFiles();
//            app.UseMvc(routes =>
//            {
//                routes.MapRoute(
//                    name: "default",
//                    template: "{controller=Home}/{action=Index}/{id?}");
//                routes.MapRoute(
//                    name: "DefaultApi",
//                    template: "api/{controller}/{action}/{id?}");
//                routes.MapSpaFallbackRoute("spa-fallback", new {controller = "Home", action = "Index"});
//            });
//        }
    }
}