using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using mySimpleMessageService.Application.Contacts;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Application.Messages.Handlers;
using mySimpleMessageService.Domain.Models;
using mySimpleMessageService.Tests.Helpers;
using Xunit;

namespace mySimpleMessageService.Tests.Application
{
    public class SendMessageCommandHandlerTests
    {

        [Theory, AutoMoqData]
        public async Task Should_TransferProperMessageToRepositoryMethod([Frozen] Mock<IMessageRepository> messageRepositoryMock,
                                                                         Mock<IContactService> contactServiceMock,
                                                                         SendMessageCommandHandler handler,
                                                                         SendMessageCommand command,
                                                                         CancellationToken token)
        {
            contactServiceMock.Setup(x => x.CheckIfExists(It.IsAny<HashSet<int>>())).Returns(() => Task.CompletedTask);

            await handler.Handle(command, token);

            messageRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Message>()), Times.Once);
        }
    }
}
