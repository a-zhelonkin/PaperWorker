using System.Collections.Generic;
using System.Linq;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class EmailMessagesRepository : IEmailMessagesRepository
    {
        private readonly DbSet<EmailMessage> _emailMessages;

        public EmailMessagesRepository(DbSet<EmailMessage> emailMessages)
        {
            _emailMessages = emailMessages;
        }

        public IEnumerable<EmailMessage> Get()
        {
            return _emailMessages.Where(x => x.Deleted == null)
                                 .Include(x => x.User);
        }

        public void Add(EmailMessage emailMessage)
        {
            _emailMessages.Add(emailMessage);
        }

        public void Update(EmailMessage emailMessage)
        {
            _emailMessages.Update(emailMessage);
        }
    }
}