﻿using mySimpleMessageService.Domain.Models;
using System;

namespace mySimpleMessageService.Application.Messages.Dtos
{
    public class MessageDto
    {
        public MessageDto(Message message)
        {
            SenderId = message.SenderId;
            RecipientId = message.RecipientId;
            PostDateTime = message.PostDateTime;
            MessageBody = message.MessageBody;
        }

        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTimeOffset PostDateTime { get; set; }
        public string MessageBody { get; set; }
    }
}
