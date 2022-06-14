using MyStore.Core.Data.Context.Postgres;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace MyStore.Core.Repository.Test.Unit
{
    public abstract class BaseRepositoryTests : TestBed<RepositoryTestsFixture>
    {
        protected readonly MyStoreDbContext _context;

        protected BaseRepositoryTests(ITestOutputHelper testOutputHelper, RepositoryTestsFixture fixture) : base(testOutputHelper, fixture)
        {
            _context = ContextManager.GetContext();
            ContextManager.GetContext().ClearAll();
        }
    }
}
