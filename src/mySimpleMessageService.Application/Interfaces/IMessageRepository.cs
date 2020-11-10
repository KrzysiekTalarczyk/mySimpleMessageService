using System.Linq;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> GetAsync(int id);
        void Remove(Message message);
        public IQueryable<MessageDto> GetMessages(ConversationRequest query);
    }
}
