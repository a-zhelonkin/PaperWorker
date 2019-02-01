using System;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Database;
using log4net;
using Microsoft.Extensions.Hosting;
using Services.Core;

namespace Services.Email
{
    public class EmailService : IHostedService, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmailService));

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFactory<MailKitClient> _mailKitClientFactory;

        private Timer _timer;

        public EmailService(IUnitOfWork unitOfWork,
                            IFactory<MailKitClient> mailKitClientFactory)
        {
            _unitOfWork = unitOfWork;
            _mailKitClientFactory = mailKitClientFactory;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Info("Email service started");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var userRepository = _unitOfWork.UserRepository;
            using (var client = _mailKitClientFactory.Create())
            {
                foreach (var user in userRepository.Get())
                {
                    switch (user.Status)
                    {
                        case UserStatus.Prepared:
                            if (client.SendInvite(user.Email))
                            {
                                user.Status = UserStatus.Pending;
                            }

                            break;
                        case UserStatus.Restoring:
                            if (client.SendRestore(user.Email))
                            {
                                user.Status = UserStatus.Pending;
                            }

                            break;
                    }

                    userRepository.Update(user);
                }

                _unitOfWork.Save();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Info("Email service stopped");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}