using Auth;
using log4net;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Services.Email
{
    public class MailKitProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MailKitProvider));

        private readonly EmailConfiguration _configuration;

        private readonly SmtpClient _emailClient;

        public MailKitProvider(EmailConfiguration configuration)
        {
            _configuration = configuration;

            _emailClient = new SmtpClient();
            _emailClient.Connect(configuration.Server, configuration.Port);
            _emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            _emailClient.Authenticate(configuration.Username, configuration.Password);
        }

        public bool SendInvite(string email)
        {
            var token = TokenGenerator.GetToken(email);
            if (token == null)
            {
                return false;
            }

            var message = new MimeMessage
            {
                Subject = "Приглашение",
                Body = new TextPart(TextFormat.Html)
                {
                    Text = $"Приходи <b style='color: red'>скорее</b> к <a href='{_configuration.InviteUrl}?token={token}'>нам</a>"
                }
            };

            message.To.Add(new MailboxAddress(email, email));
            message.From.Add(new MailboxAddress("PaperWorker", _configuration.Username));

            _emailClient.Send(message);

            Log.Debug($"Mail send to {email}");

            return true;
        }

        public void Dispose()
        {
            _emailClient.Disconnect(true);
            _emailClient.Dispose();
        }
    }
}