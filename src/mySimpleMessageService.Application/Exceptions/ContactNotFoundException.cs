using System;

namespace mySimpleMessageService.Application.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(int id) : base($"Contact with Id {id} not found")
        {
        }
    }
}
