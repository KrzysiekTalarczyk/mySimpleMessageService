using Microsoft.Extensions.Options;
using mySimpleMessageService.Application.Contacts.Dtos;
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
            mapper.Property<ContactDto>(x => x.Name).CanFilter().CanSort().HasName("Name");
            mapper.Property<ContactDto>(x => x.Id).CanFilter().CanSort().HasName("Id");
            return mapper;
        }
    }
}
