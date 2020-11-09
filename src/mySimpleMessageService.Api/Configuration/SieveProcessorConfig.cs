using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace mySimpleMessageService.Api.Configuration
{
    public class SieveProcessorConfig : SieveProcessor
    {
        public SieveProcessorConfig(IOptions<SieveOptions> options)
            : base(options)
        {
        }
    }
}
