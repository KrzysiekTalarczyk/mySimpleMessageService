using System;
using System.Collections.Generic;
using mySimpleMessageService.Application.Contacts.Handlers;

namespace mySimpleMessageService.Application.Messages.Dtos
{
   public class ConversationRequest
   {
       public HashSet<int> Contacts { get; set; }

       //public DateTimeOffset Start { get; set; }
       //public DateTimeOffset End { get; set; }
    }
}
