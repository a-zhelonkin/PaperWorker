using System.Collections.Generic;
using Database.Models;

namespace Database.Repositories
{
    public interface IEmailMessagesRepository
    {
        IEnumerable<EmailMessage> Get();
        void Add(EmailMessage emailMessage);
        void Update(EmailMessage emailMessage);
    }
}