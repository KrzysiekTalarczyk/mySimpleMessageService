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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne<Contact>(m => m.Sender)
                .WithMany(c => c.SenderMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne<Contact>(m => m.Recipient)
                .WithMany(c => c.RecipientMessages)
                .HasForeignKey(m => m.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
