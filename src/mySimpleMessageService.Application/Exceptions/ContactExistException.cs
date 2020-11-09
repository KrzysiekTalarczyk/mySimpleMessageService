using System;

namespace mySimpleMessageService.Application.Exceptions
{
    public class ContactExistException : Exception
    {
        public ContactExistException(string name) : base($"Contact with Name {name} already exist")
        {

        }
    }
}
