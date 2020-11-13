using System;

namespace mySimpleMessageService.Application.Messages.Dtos
{
    public class MessageDto
    {
        public MessageDto(int senderId, int recipientId, DateTimeOffset postDateTime, string messageBody)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            PostDateTime = postDateTime;
            MessageBody = messageBody;
        }

        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTimeOffset PostDateTime { get; set; }
        public string MessageBody { get; set; }
    }
}
