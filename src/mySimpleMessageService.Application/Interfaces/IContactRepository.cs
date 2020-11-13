using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    public interface IContactRepository
    {
        IQueryable<ContactDto> GetAllAsync();
        Task AddNewAsync(Contact contact);
        void Delete(Contact contact);
        Task<Contact> GetAsync(int id);
        Task<IEnumerable<Contact>> GetAsync(HashSet<int> ids);
        Task<Contact> GetByNameAsync(string name);
        public Task CompleteAsync();
    }
}
