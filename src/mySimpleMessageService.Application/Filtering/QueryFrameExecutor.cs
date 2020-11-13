using System.Collections.Generic;
using System.Linq;
using Sieve.Models;
using Sieve.Services;

namespace mySimpleMessageService.Application.Filtering
{
    public class QueryFrameExecutor : IQueryFrameExecutor
    {
        private readonly ISieveProcessor _sieveProcessor;
        public QueryFrameExecutor(ISieveProcessor sieveProcessor)
        {
            _sieveProcessor = sieveProcessor;
        }

        public IEnumerable<T> SelectData<T>(IEnumerable<T> value, SieveModel sieveModel, out int totalResultCount)
        {
            var results = _sieveProcessor.Apply(sieveModel, value.AsQueryable(), applyPagination: false);
            totalResultCount = results.Count();
            var onePageResults = _sieveProcessor.Apply(sieveModel, results, applyFiltering: false, applySorting: false, applyPagination: true);
            return onePageResults;
        }
    }
}
