using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Contacts.Handlers;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Exceptions;
using mySimpleMessageService.Domain.Models;
using mySimpleMessageService.Tests.Helpers;
using Xunit;

namespace mySimpleMessageService.Tests.Application
{
    public class CreateContactCommandHandlerTests
    {
        [Theory, AutoMoqData]
        public async Task Should_ThrowError_When_ContactName_IsEmpty()
        {
            Assert.Throws<ContactValidationException>(() => Contact.Create(string.Empty));
        }

        [Theory, AutoMoqData]
        public async Task Should_Invoke_RepositoryAddNew_Method([Frozen] Mock<IContactRepository> contactRepositoryMock,
                                                                CreateContactCommandHandler handler,
                                                                CancellationToken token,
                                                                CreateContactCommand command)
        {
            contactRepositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>()))
                                 .ReturnsAsync(() => null);

            await handler.Handle(command, token);

            contactRepositoryMock.Verify(x => x.AddNewAsync(It.IsAny<Contact>()), Times.Once);
        }

        [Theory, AutoMoqData]
        public async Task Should_ThrowError_When_ContactName_Exist([Frozen] Mock<IContactRepository> contactRepositoryMock,
                                                                    CreateContactCommandHandler handler,
                                                                    CancellationToken token,
                                                                    CreateContactCommand command)
        {
            contactRepositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(Contact.Create(command.Name));

            await Assert.ThrowsAsync<ContactExistException>(async () => await handler.Handle(command, token));
        }

    }
}
