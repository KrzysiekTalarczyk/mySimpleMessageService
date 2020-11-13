using System.Collections.Generic;
using Sieve.Models;

namespace mySimpleMessageService.Application.Filtering
{
    public interface IQueryFrameExecutor
    {
        IEnumerable<T> SelectData<T>(IEnumerable<T> value, SieveModel sieveModel, out int totalResultCount);
    }
}