using System;
using Auth;
using log4net;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Services.Email
{
    internal class MailKitClient : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MailKitClient));

        private readonly ITokenGenerator _tokenGenerator;
        private readonly EmailConfiguration _configuration;
        private readonly SmtpClient _client;

        public MailKitClient(ITokenGenerator tokenGenerator,
                             EmailConfiguration configuration)
        {
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;

            _client = new SmtpClient();
            _client.Connect(_configuration.Server, _configuration.Port);
            _client.AuthenticationMechanisms.Remove("XOAUTH2");
            _client.Authenticate(_configuration.Username, _configuration.Password);
        }

        public void Dispose() => _client?.Dispose();

        public bool SendInvite(string email)
        {
            var token = _tokenGenerator.GetToken(email);
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

            _client.Send(message);

            Log.Debug($"Mail send invite to {email}");
            return true;
        }

        public bool SendRestore(string email)
        {
            var token = _tokenGenerator.GetToken(email);
            if (token == null)
            {
                return false;
            }

            var message = new MimeMessage
            {
                Subject = "Восстановление пароля",
                Body = new TextPart(TextFormat.Html)
                {
                    Text = $"Для восстановления пароля <b style='color: red'>скорее</b> <a href='{_configuration.ChangePasswordUrl}?token={token}'>сюда</a>"
                }
            };

            message.To.Add(new MailboxAddress(email, email));
            message.From.Add(new MailboxAddress("PaperWorker", _configuration.Username));

            _client.Send(message);

            Log.Debug($"Mail send change password to {email}");
            return true;
        }

        public bool SendAuthLink(string email)
        {
            var token = _tokenGenerator.GetToken(email);
            if (token == null)
            {
                return false;
            }

            var message = new MimeMessage
            {
                Subject = "Вход",
                Body = new TextPart(TextFormat.Html)
                {
                    Text = $"Для входа <b style='color: red'>скорее</b> <a href='{_configuration.AuthLinkUrl}?token={token}'>сюда</a>"
                }
            };

            message.To.Add(new MailboxAddress(email, email));
            message.From.Add(new MailboxAddress("PaperWorker", _configuration.Username));

            _client.Send(message);

            Log.Debug($"Mail send auth link {email}");
            return true;
        }
    }
}