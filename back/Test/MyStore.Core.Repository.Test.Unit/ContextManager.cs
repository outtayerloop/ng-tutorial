using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using System;

namespace MyStore.Core.Repository.Test.Unit
{
    public static class ContextManager
    {
        public static string ConnectionString { get; } = GetConnectionString();

        public static string InMemoryDatabase { get; } = "test";

        private static MyStoreDbContext? _context;

        public static MyStoreDbContext GetContext()
        {
            if (_context == null)
                _context = CreateContext();
            return _context;
        }

        private static MyStoreDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<MyStoreDbContext>().UseInMemoryDatabase(InMemoryDatabase).Options;
            return new MyStoreDbContext(options);
        }

        private static string GetConnectionString()
            => Environment.GetEnvironmentVariable("MY_STORE_TEST_CONNECTION_STRING")!;
    }
}
