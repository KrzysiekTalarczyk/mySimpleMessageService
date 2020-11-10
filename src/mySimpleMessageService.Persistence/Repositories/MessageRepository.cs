using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SimpleMessageServiceDbContext _context;
        public MessageRepository(SimpleMessageServiceDbContext context)
        {
            _context = context;
        }

        public Task<Message> GetAsync(int id) => _context.Messages.FirstOrDefaultAsync(m => m.Id == id);

        public void Remove(Message message)
        {
            _context.Messages.Remove(message);
        }

        public IQueryable<MessageDto> GetMessages(ConversationRequest query)
        {
            return _context.Messages.Where(m => query.Contacts.Contains(m.SenderId) &&
                                                query.Contacts.Contains(m.RecipientId))
                                    .Select(m => new MessageDto(m));
        }
    }
}
