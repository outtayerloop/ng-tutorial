using MyStore.Core.Data.Context.Postgres;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

[assembly: TestCollectionOrderer("MyStore.Core.Repository.Test.Unit.TestsOrderer", "UnitTestsOrderer")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace MyStore.Core.Repository.Test.Unit
{
    public abstract class BaseTests : TestBed<UnitTestsFixture>
    {
        protected readonly MyStoreDbContext _context;

        protected BaseTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture) : base(testOutputHelper, fixture)
            => _context = ContextManager.GetContext();
    }
}
