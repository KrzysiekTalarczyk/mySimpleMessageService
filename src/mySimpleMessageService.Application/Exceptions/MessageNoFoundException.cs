using System;

namespace mySimpleMessageService.Application.Exceptions
{
    public class MessageNoFoundException : Exception
    {
        public MessageNoFoundException(int id) : base($"Message with Id {id} not found")
        {
        }
    }
}
