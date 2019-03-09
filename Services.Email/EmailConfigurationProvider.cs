using Microsoft.Extensions.Configuration;
using Core;
using Services.Core.Configurations;

namespace Services.Email
{
    internal class EmailConfigurationProvider : IConfigurationProvider<EmailConfiguration>
    {
        private readonly IAppConfigurations _appConfigurations;

        public EmailConfigurationProvider(IAppConfigurations appConfigurations)
        {
            _appConfigurations = appConfigurations;
        }

        public EmailConfiguration Provide()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("email.settings.json")
                                .Build()
                                .GetSection(nameof(EmailConfiguration))
                                .Get<EmailConfiguration>();

            var origin = _appConfigurations.Origin;
            configuration.CabinetUrl = origin + configuration.CabinetUrl;
            configuration.ChangePasswordUrl = origin + configuration.ChangePasswordUrl;

            return configuration;
        }
    }
}