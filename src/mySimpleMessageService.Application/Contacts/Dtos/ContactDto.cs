using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Contacts.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static ContactDto Map(Contact contact) => new ContactDto(){Name = contact.Name};
    }
}
