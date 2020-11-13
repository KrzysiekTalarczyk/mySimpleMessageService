using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using mySimpleMessageService.Application.Contacts;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Contacts.Handlers;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;
using mySimpleMessageService.Tests.Helpers;
using Xunit;

namespace mySimpleMessageService.Tests.Application
{
    public class ContactServiceTests
    {
        [Theory, AutoMoqData]
        public async Task Should_Invoke_RepositoryAddNewMethod([Frozen] Mock<IContactRepository> contactRepositoryMock,
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
        public async Task Should_ThrowError_When_ContactNotFound([Frozen] Mock<IContactRepository> contactRepositoryMock,
            ContactService service, int id)
        {
            contactRepositoryMock.Setup(x => x.GetAsync(id)).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<ContactNotFoundException>(async () => await service.GetContactAsync(id));
        }

        [Theory, AutoMoqData]
        public async Task Should_ReturnContact_When_ContactWasFound([Frozen] Mock<IContactRepository> contactRepositoryMock,
            ContactService service, Contact contact)
        {
            contactRepositoryMock.Setup(x => x.GetAsync(contact.Id)).ReturnsAsync(contact);

            var result = await service.GetContactAsync(contact.Id);

            Assert.Equal(result, contact);
        }

        [Theory, AutoMoqData]
        public async Task Should_ThrowError_When_ContactsNotExists([Frozen] Mock<IContactRepository> contactRepositoryMock,
            ContactService service, HashSet<int> ids)
        {
            contactRepositoryMock.Setup(x => x.GetAsync(ids)).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<ContactNotFoundException>(async () => await service.CheckIfExists(ids));
        }


        [Theory, AutoMoqData]
        public async Task Should_ThrowError_When_OneContactNotExists([Frozen] Mock<IContactRepository> contactRepositoryMock,
            ContactService service, Contact contact, int id2)
        {
            var ids = new HashSet<int>() { contact.Id, id2 };
            contactRepositoryMock.Setup(x => x.GetAsync(ids)).ReturnsAsync(new List<Contact>() { contact });

            await Assert.ThrowsAsync<ContactNotFoundException>(async () => await service.CheckIfExists(ids));
        }

        [Theory, AutoMoqData]
        public async Task Should_NotThrowError_When_ContactsExists([Frozen] Mock<IContactRepository> contactRepositoryMock,
            ContactService service, Contact contact, Contact contact2)
        {
            var ids = new HashSet<int>() { contact.Id, contact2.Id };
            contactRepositoryMock.Setup(x => x.GetAsync(ids)).ReturnsAsync(new List<Contact>() { contact, contact2 });

            var exception = await Record.ExceptionAsync(() => service.CheckIfExists(ids));

            Assert.Null(exception);
        }

    }
}
