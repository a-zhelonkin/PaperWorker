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

        public MailKitProvider(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SmtpClient CreateEmailClient()
        {
            var emailClient = new SmtpClient();
            emailClient.Connect(_configuration.Server, _configuration.Port);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.Authenticate(_configuration.Username, _configuration.Password);
            return emailClient;
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
                    Text =
                        $"Приходи <b style='color: red'>скорее</b> к <a href='{_configuration.InviteUrl}?token={token}'>нам</a>"
                }
            };

            message.To.Add(new MailboxAddress(email, email));
            message.From.Add(new MailboxAddress("PaperWorker", _configuration.Username));

            using (var client = CreateEmailClient())
            {
                client.Send(message);
            }

            Log.Debug($"Mail send invite to {email}");

            return true;
        }

        public bool SendRestore(string email)
        {
            var token = TokenGenerator.GetToken(email);
            if (token == null)
            {
                return false;
            }

            var message = new MimeMessage
            {
                Subject = "Восстановление пароля",
                Body = new TextPart(TextFormat.Html)
                {
                    Text =
                        $"Для восстановления пароля <b style='color: red'>скорее</b> к <a href='{_configuration.ChangePasswordUrl}?token={token}'>сюда</a>"
                }
            };

            message.To.Add(new MailboxAddress(email, email));
            message.From.Add(new MailboxAddress("PaperWorker", _configuration.Username));

            using (var client = CreateEmailClient())
            {
                client.Send(message);
            }

            Log.Debug($"Mail send change password to {email}");

            return true;
        }
    }
}