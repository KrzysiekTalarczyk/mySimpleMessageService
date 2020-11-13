using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Contacts;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Dtos;

namespace mySimpleMessageService.Application.Messages
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public IQueryable<MessageDto> GetUsersMessages(HashSet<int> contactIds)
        {
            var query = new ConversationRequest() { Contacts = contactIds };
            return _messageRepository.GetMessagesBetweenContacts(query);
        }
    }
}
