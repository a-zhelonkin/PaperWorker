using Microsoft.Extensions.DependencyInjection;
using Core;

namespace Services.Email
{
    public static class EmailServiceDiExtension
    {
        public static void AddEmailService(this IServiceCollection services)
        {
            services.AddHostedService<EmailService>();

            services.AddScoped<IFactory<MailKitClient>, MailKitClientFactory>();
            services.AddScoped<IConfigurationProvider<EmailConfiguration>, EmailConfigurationProvider>();
        }
    }
}