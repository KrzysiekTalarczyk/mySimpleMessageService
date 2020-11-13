using Microsoft.Extensions.Options;
using mySimpleMessageService.Domain.Models;
using Sieve.Models;
using Sieve.Services;

namespace mySimpleMessageService.Application.Filtering
{
    public class SieveProcessorConfig : SieveProcessor
    {
        public SieveProcessorConfig(IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Contact>(x => x.Name).CanFilter().CanSort().HasName("Name");
            mapper.Property<Contact>(x => x.Id).CanFilter().CanSort().HasName("Id");

            mapper.Property<Message>(x => x.MessageBody).CanFilter().CanSort();
            mapper.Property<Message>(x => x.PostDateTime).CanFilter().CanSort();
            return mapper;
        }
    }
}
