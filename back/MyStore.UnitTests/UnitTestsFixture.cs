using Xunit.Microsoft.DependencyInjection.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MyStore.Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit.Microsoft.DependencyInjection;
using MyStore.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MyStore.UnitTests
{
    public class UnitTestsFixture : TestBedFixture
    {
        public UnitTestsFixture()
            => ContextManager.GetContext().ClearAll();

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services.AddSingleton(typeof(IStoreRepository<>), typeof(StoreRepository<>));
            string connectionString = ContextManager.ConnectionString;
            services.AddDbContext<MyStoreDbContext>(options => options.UseNpgsql(connectionString));
        }

        protected override ValueTask DisposeAsyncCore()
            => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = null, IsOptional = true };
        }

        protected override void Dispose(bool disposing)
        {
            ContextManager.GetContext().ClearAll();
            base.Dispose(disposing);
        }
    }
}
