using System.Collections.Generic;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task AddNewAsync(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
