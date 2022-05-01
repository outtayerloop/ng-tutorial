﻿using Microsoft.EntityFrameworkCore;
using MyStore.Core.Database;
using MyStore.Core.Domain.Common;

namespace MyStore.Core.Repository
{
    public class StoreRepository<T> : IStoreRepository<T> where T : BaseModel
    {
        private readonly DbSet<T> _models;

        public StoreRepository(MyStoreDbContext context)
            => _models = context.Set<T>();

        public List<T> GetAll()
            => _models.ToList();
    }
}
