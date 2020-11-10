using System;

namespace mySimpleMessageService.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public int RecipientId { get; set; }

        public DateTimeOffset Created { get; set; }
        public MessageContent MessageContent { get; set; }

        private Message()
        {
        }

        public static Message Create(int senderId, MessageContent content, int recipientId)
        {
            return new Message()
            {
                SenderId = senderId,
                RecipientId = recipientId,
                MessageContent  = content,
                Created = DateTimeOffset.Now
            };
        }
    }
}
