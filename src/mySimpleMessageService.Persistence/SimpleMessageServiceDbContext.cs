using Microsoft.EntityFrameworkCore;
using mySimpleMessageService.Domain.Models;

namespace mySimpleMessageService.Persistence
{
    public class SimpleMessageServiceDbContext : DbContext
    {

        public SimpleMessageServiceDbContext(DbContextOptions<SimpleMessageServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
