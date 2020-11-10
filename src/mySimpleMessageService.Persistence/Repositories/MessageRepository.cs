using System;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Task<Message> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
