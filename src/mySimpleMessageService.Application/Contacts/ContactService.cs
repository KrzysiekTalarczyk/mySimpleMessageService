using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mySimpleMessageService.Application.Exceptions;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Application.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository repository)
        {
            _contactRepository = repository;
        }

        public async Task<Contact> GetContactAsync(int id) =>
           await _contactRepository.GetAsync(id) ?? throw new ContactNotFoundException(id);


        public async Task CheckIfExists(HashSet<int> ids)
        {
            var results = await _contactRepository.GetAsync(ids);

            if (results is null || results.Count() != ids.Count)
                throw new ContactNotFoundException(ids);
        }
    }
}
