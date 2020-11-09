using mySimpleMessageService.Domain.Exceptions;
using mySimpleMessageService.Domain.Models;
using mySimpleMessageService.Tests.Helpers;
using Xunit;

namespace mySimpleMessageService.Tests.Domain
{
    public class ContactTests
    {
        [Fact]
        public void Should_ThrowError_When_ContactName_IsEmpty()
        {
            Assert.Throws<ContactValidationException>(() => Contact.Create(string.Empty));
        }

        [Theory, AutoMoqData]
        public void Should_Return_NewContact(string name)
        {
            var contact = Contact.Create(name);
            
            Assert.Equal(name, contact.Name);
        }

    }
}
