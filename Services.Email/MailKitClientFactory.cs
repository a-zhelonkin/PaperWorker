using Auth;
using Core;

namespace Services.Email
{
    internal class MailKitClientFactory : IFactory<MailKitClient>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly EmailConfiguration _emailConfiguration;

        public MailKitClientFactory(ITokenGenerator tokenGenerator,
                                    IConfigurationProvider<EmailConfiguration> configurationProvider)
        {
            _tokenGenerator = tokenGenerator;
            _emailConfiguration = configurationProvider.Provide();
        }

        public MailKitClient Create()
        {
            return new MailKitClient(_tokenGenerator, _emailConfiguration);
        }
    }
}