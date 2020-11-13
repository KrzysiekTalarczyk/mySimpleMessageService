using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Contacts
{
    public interface IContactService
    {
        Task<Contact> GetContactAsync(int id);
        Task CheckIfExists(HashSet<int> ids);
    }
}