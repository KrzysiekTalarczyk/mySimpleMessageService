using System.Threading.Tasks;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> GetAsync(int id);
        Task RemoveAsync(Message message);
    }
}
