using System;
using System.Linq;
using Auth;
using Core;
using Database;
using Database.Models.Account;
using Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<PaperWorkerDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddEmailService();

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUnitOfWork unitOfWork)
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

            using (unitOfWork)
            {
                CreateRoles(unitOfWork.RolesRepository);
            }
        }

        private static void CreateRoles(IRolesRepository rolesRepository)
        {
            var roleNames = Enum.GetValues(typeof(RoleName)).Cast<RoleName>();

            foreach (var roleName in roleNames)
            {
                if (rolesRepository.ExistsRole(roleName)) continue;

                rolesRepository.AddRole(new Role {Name = roleName});
            }
        }
    }
}