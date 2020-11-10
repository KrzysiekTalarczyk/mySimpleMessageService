using System;
using System.Collections.Generic;

namespace mySimpleMessageService.Application.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(int id) : base($"Contact with Id {id} not found")
        {
        }
        public ContactNotFoundException(HashSet<int> ids) : base($"Contact with Ids {ids} not found")
        {
        }
    }
}
