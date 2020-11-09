using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task AddNewAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<Contact> GetAsync(int id);
        Task<Contact> GetByNameAsync(string name);
        Task UpdateAsync(Contact contact);
    }
}
