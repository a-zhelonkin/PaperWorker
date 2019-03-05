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
    internal class EmailService : IHostedService, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EmailService));

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFactory<MailKitClient> _mailKitClientFactory;
        private readonly Mutex _mutex;

        private Timer _timer;

        public EmailService(IUnitOfWork unitOfWork,
                            IFactory<MailKitClient> mailKitClientFactory)
        {
            _unitOfWork = unitOfWork;
            _mailKitClientFactory = mailKitClientFactory;
            _mutex = new Mutex();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Info("Email service started");

            _timer = new Timer(DoWorkSafe, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWorkSafe(object state)
        {
            try
            {
                _mutex.WaitOne();

                DoWork();
            }
            catch (Exception e)
            {
                Log.Error("Error while email service working", e);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        private void DoWork()
        {
            var userRepository = _unitOfWork.UserRepository;
            var emailMessagesRepository = _unitOfWork.EmailMessagesRepository;
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
                        default:
                            continue;
                    }

                    userRepository.Update(user);
                }

                foreach (var emailMessage in emailMessagesRepository.Get())
                {
                    switch (emailMessage.Type)
                    {
                        case MessageType.RestoreRequest:
                            if (client.SendRestore(emailMessage.User.Email))
                            {
                                emailMessage.Deleted = DateTime.Now;
                            }

                            break;
                        case MessageType.AuthLinkRequest:
                            if (client.SendAuthLink(emailMessage.User.Email))
                            {
                                emailMessage.Deleted = DateTime.Now;
                            }

                            break;
                        default:
                            continue;
                    }

                    emailMessagesRepository.Update(emailMessage);
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