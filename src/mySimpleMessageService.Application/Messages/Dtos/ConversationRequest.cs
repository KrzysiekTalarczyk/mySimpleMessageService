using System.Collections.Generic;

namespace mySimpleMessageService.Application.Messages.Dtos
{
    public class ConversationRequest
    {
        public HashSet<int> Contacts { get; set; }
    }
}
