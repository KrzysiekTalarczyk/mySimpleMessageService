using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly SimpleMessageServiceDbContext _context;
        public ContactRepository(SimpleMessageServiceDbContext context)
        {
            _context = context;
        }
        public IQueryable<ContactDto> GetAllAsync()
        {
            return _context.Contacts.AsNoTracking().Where(c => !c.Deleted).Select(c => new ContactDto(c));
        }

        public async Task AddNewAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public void Delete(Contact contact)
        {
            contact.Deleted = true;
        }

        public Task<Contact> GetAsync(int id)
        {
            return _context.Contacts.FirstOrDefaultAsync(c =>!c.Deleted && c.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetAsync(HashSet<int> ids)
        {
            return await _context.Contacts.Where(x => !x.Deleted && ids.Contains(x.Id)).Select(c => c).ToListAsync();
        }

        public Task<Contact> GetByNameAsync(string name)
        {
            return _context.Contacts.AsNoTracking().FirstOrDefaultAsync(c => !c.Deleted && c.Name.Equals(name));
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
