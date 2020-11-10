using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    public interface IMessageService
    {
        Task SaveMessageAsync(Message message);
    }
}
