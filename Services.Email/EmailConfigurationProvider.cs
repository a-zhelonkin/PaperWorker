using Microsoft.Extensions.Configuration;
using Services.Core;

namespace Services.Email
{
    internal class EmailConfigurationProvider : IConfigurationProvider<EmailConfiguration>
    {
        public EmailConfiguration Provide() =>
            new ConfigurationBuilder()
                .AddJsonFile("email.settings.json")
                .Build()
                .GetSection(nameof(EmailConfiguration))
                .Get<EmailConfiguration>();
    }
}