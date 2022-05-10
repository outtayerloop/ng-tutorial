﻿using MyStore.Core.Data.Context;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

[assembly: TestCollectionOrderer("MyStore.UnitTests.TestsOrderer", "UnitTestsOrderer")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace MyStore.UnitTests
{
    public abstract class BaseTests : TestBed<UnitTestsFixture>
    {
        protected readonly MyStoreDbContext _context;

        protected BaseTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture) : base(testOutputHelper, fixture)
            => _context = ContextManager.GetContext();
    }
}
