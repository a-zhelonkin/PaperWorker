using System;
using System.Linq;
using System.Threading.Tasks;
using Auth;
using Core;
using Database;
using Database.Extensions;
using Database.Models.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Email;

namespace Front
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration.GetConnectionString(nameof(PaperWorkerDbContext));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<EmailService>();

            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = AuthConstants.Issuer,
                        ValidAudience = AuthConstants.Audience,
                        IssuerSigningKey = AuthConstants.SymmetricSecurityKey,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("DefaultApi", "api/{controller}/{action}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new {controller = "Home", action = "Index"});
            });

            CreateRoles().Wait();
        }

        private static async Task CreateRoles()
        {
            using (var context = new PaperWorkerDbContext())
            {
                var roleNames = Enum.GetValues(typeof(RoleName)).Cast<RoleName>();
                foreach (var roleName in roleNames)
                {
                    if (await context.ExistsRole(roleName)) continue;

                    await context.AddRole(new Role {Name = roleName});
                }
            }
        }
    }
}