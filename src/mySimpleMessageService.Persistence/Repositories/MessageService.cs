using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence.Repositories
{
    public class MessageService : IMessageService
    {
        public Task SaveMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
