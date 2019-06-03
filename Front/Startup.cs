using System;
using Api.Mappers;
using Api.Models;
using Api.Models.Account;
using Auth;
using Core;
using Database;
using Database.Models;
using Database.Models.Account;
using Front.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Core.Configurations;
using Services.Email;

namespace Front
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                             .SetBasePath(env.ContentRootPath)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                             .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<PaperWorkerDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IMapper<User, UserDto>, UserDtoMapper>();
            services.AddScoped<IMapper<Profile, ProfileDto>, ProfileDtoMapper>();
            services.AddScoped<IMapper<ProfileDto, Profile>, DtoProfileMapper>();
            services.AddScoped<IAppConfigurations, AppConfigurations>(provider => _configuration.GetSection(nameof(AppConfigurations)).Get<AppConfigurations>());

            services.AddEmailService();

            services.AddMvc();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = false;
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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<JwtFromCookieMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("api", "api/{controller}/{action}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new {controller = "Home", action = "Index"});
            });
        }
    }
}