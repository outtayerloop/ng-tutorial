using Microsoft.EntityFrameworkCore;
using MyStore.Core.Database;
using System;

namespace MyStore.UnitTests
{
    public static class ContextManager
    {
        private static MyStoreDbContext _context;

        public static MyStoreDbContext GetContext()
        {
            if (_context == null)
                _context = CreateContext();
            return _context;
        }

        private static MyStoreDbContext CreateContext()
        {
            string connectionString = Environment.GetEnvironmentVariable("MY_STORE_TEST_CONNECTION_STRING");
            var options = new DbContextOptionsBuilder<MyStoreDbContext>().UseNpgsql(connectionString).Options;
            return new MyStoreDbContext(options);
        }
    }
}
