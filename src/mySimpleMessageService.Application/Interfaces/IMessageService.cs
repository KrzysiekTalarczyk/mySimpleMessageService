using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    interface IMessageService
    {
        Task SaveMessageAsync(Message message);
        Task<IEnumerable<MessageDto>> GetUsersMessages(int[] ints);
    }
}
