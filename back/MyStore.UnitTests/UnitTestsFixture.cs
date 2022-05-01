using Xunit.Microsoft.DependencyInjection.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MyStore.Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit.Microsoft.DependencyInjection;

namespace MyStore.UnitTests
{
    public class UnitTestsFixture : TestBedFixture
    {
        private static readonly object _lock = new();

        private static bool _databaseInitialized;

        public UnitTestsFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = ContextManager.GetContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }
                    _databaseInitialized = true;
                }
            }
        }

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
            => services.AddSingleton(typeof(IStoreRepository<>), typeof(StoreRepository<>));

        protected override ValueTask DisposeAsyncCore()
            => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = null, IsOptional = true };
        }
    }
}
