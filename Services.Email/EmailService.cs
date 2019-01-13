using System;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Database;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Services.Email
{
    public class EmailService : IHostedService, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmailService));

        private readonly MailKitProvider _emailProvider;

        private Timer _timer;

        public EmailService()
        {
            _emailProvider = new MailKitProvider(
                new ConfigurationBuilder()
                    .AddJsonFile("email.settings.json")
                    .Build()
                    .GetSection(nameof(EmailConfiguration))
                    .Get<EmailConfiguration>()
            );
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Info("Email service started");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var context = new PaperWorkerDbContext())
            {
                foreach (var user in context.Users)
                {
                    switch (user.Status)
                    {
                        case UserStatus.Prepared:
                        {
                            if (_emailProvider.SendInvite(user.Email))
                            {
                                user.Status = UserStatus.Pending;
                            }

                            break;
                        }
                        case UserStatus.Restoring:
                            if (_emailProvider.SendRestore(user.Email))
                            {
                                user.Status = UserStatus.Pending;
                            }

                            break;
                    }

                    context.Users.Update(user);
                }

                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Info("Email service stopped");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}