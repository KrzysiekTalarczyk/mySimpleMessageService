using mySimpleMessageService.Domain.Models;
using System;

namespace mySimpleMessageService.Application.Messages.Dtos
{
    public class MessageDto
    {
        private Message m;

        public MessageDto(Message m)
        {
            this.m = m;
        }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTimeOffset Create { get; set; }
        public string Text { get; set; } // to do change
    }
}
