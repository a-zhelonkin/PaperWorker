using Auth;
using Services.Core;

namespace Services.Email
{
    public class MailKitClientFactory : IFactory<MailKitClient>
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly EmailConfiguration _emailConfiguration;

        public MailKitClientFactory(TokenGenerator tokenGenerator,
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