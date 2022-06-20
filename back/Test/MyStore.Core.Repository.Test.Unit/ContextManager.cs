using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using System;

namespace MyStore.Core.Repository.Test.Unit
{
    public static class ContextManager
    {
        public static string ConnectionString { get; } = GetConnectionString();

        public static string InMemoryDatabase { get; } = "test";

        public static MyStoreDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<MyStoreDbContext>().UseInMemoryDatabase(InMemoryDatabase).Options;
            var context = new MyStoreDbContext(options);
            context.ClearAll();
            return context;
        }

        private static string GetConnectionString()
            => Environment.GetEnvironmentVariable("MY_STORE_TEST_CONNECTION_STRING")!;
    }
}
