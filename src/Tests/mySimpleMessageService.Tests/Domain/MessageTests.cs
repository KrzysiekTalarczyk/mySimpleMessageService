using System;
using mySimpleMessageService.Domain.Models;
using mySimpleMessageService.Tests.Helpers;
using Xunit;

namespace mySimpleMessageService.Tests.Domain
{
    public class MessageTests
    {
        [Theory, AutoMoqData]
        public void Should_Return_NewMessage(int senderId, string body, int recipientId)
        {
            var message = Message.Create(senderId, body, recipientId);

            Assert.Equal(body, message.MessageBody);
            Assert.Equal(senderId, message.SenderId);
            Assert.Equal(recipientId, message.RecipientId);
        }

        [Theory, AutoMoqData]
        public void Should_CreateMessage_With_ProperDateTime(int senderId, string body, int recipientId)
        {
            var message = Message.Create(senderId, body, recipientId);

            Assert.True(DateTimeOffset.Now > message.PostDateTime);
        }
    }
}
