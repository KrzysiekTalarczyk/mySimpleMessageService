using System;

namespace mySimpleMessageService.Application.Exceptions
{
    class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(int id) : base($"Contact with Id {id} not found")
        {
        }
    }
}
