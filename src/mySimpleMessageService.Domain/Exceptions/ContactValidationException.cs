using System;

namespace mySimpleMessageService.Domain.Exceptions
{
    public class ContactValidationException : Exception
    {
        public ContactValidationException(string name) : base($"Invalid contact name {name}")
        {
            
        }
    }
}
