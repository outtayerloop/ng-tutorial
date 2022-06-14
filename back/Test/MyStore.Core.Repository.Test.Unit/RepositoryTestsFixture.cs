using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Repository.Products;
using MyStore.Core.Repository.Shippings;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace MyStore.Core.Repository.Test.Unit
{
    public class RepositoryTestsFixture : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services.AddSingleton(typeof(IStoreRepository<>), typeof(StoreRepository<>));
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IShippingRepository, ShippingRepository>();
            services.AddDbContext<MyStoreDbContext>(options => options.UseInMemoryDatabase(ContextManager.InMemoryDatabase));
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
