using System;

namespace mySimpleMessageService.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string MessageBody { get; set; }
        public DateTimeOffset PostDateTime { get; set; }

        private Message()
        {
        }

        public static Message Create(int senderId, string body, int recipientId)
        {
            return new Message()
            {
                SenderId = senderId,
                RecipientId = recipientId,
                MessageBody = body,
                PostDateTime = DateTimeOffset.Now
            };
        }
    }
}
