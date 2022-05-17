using Microsoft.EntityFrameworkCore;

namespace MyStore.Core.Data.Context.Postgres
{
    internal abstract class BaseConfiguration
    {
        protected readonly ModelBuilder _modelBuilder;

        public BaseConfiguration(ModelBuilder modelBuilder)
            => _modelBuilder = modelBuilder;

        public abstract void Configure();
    }
}
