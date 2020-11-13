using System;
using System.Collections.Generic;

namespace mySimpleMessageService.Application.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(int id) : base($"Contact with Id {id} not found")
        {
        }

        public ContactNotFoundException(HashSet<int> ids) : base($"All contacts or one of them not found. Ids: {string.Join(", ", ids)}")
        {
        }
    }
}
