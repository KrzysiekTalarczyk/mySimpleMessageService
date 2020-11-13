using mySimpleMessageService.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace mySimpleMessageService.Application.Contacts.Dtos
{
    public class FilteredResponse<T>
    {
        public IEnumerable<T> Results { get; }
        public int TotalResultCount { get; }

        public FilteredResponse(IEnumerable<T> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }
    }
}
