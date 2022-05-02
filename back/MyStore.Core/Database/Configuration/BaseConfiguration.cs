using Microsoft.EntityFrameworkCore;

namespace MyStore.Core.Database.Configuration
{
    public abstract class BaseConfiguration
    {
        protected readonly ModelBuilder _modelBuilder;

        public BaseConfiguration(ModelBuilder modelBuilder)
            => _modelBuilder = modelBuilder;

        public abstract void Configure();
    }
}
