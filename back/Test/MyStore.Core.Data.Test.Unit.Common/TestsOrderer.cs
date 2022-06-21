using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MyStore.Core.Data.Test.Unit.Common
{
    public class TestsOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
            => testCollections.OrderBy(collection => collection.DisplayName);
    }
}
